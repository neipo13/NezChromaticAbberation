sampler _mainTex;
float2 _offset;
float _radius;
float2 _center;

float4 frag(float2 uv : TEXCOORD0) : COLOR0
{
    //basically just move blue and red in opposite ways
    //have strength of effect contingent on _offset and _distancefrompoint related to its radius
    float dist = distance(_center, uv);
    float colR = tex2D(_mainTex, float2(uv.x - (_offset.x * clamp(1 - (dist / _radius), 0, 1)), uv.y - (_offset.y * clamp(1 - (dist / _radius), 0, 1)))).r;
    float colG = tex2D(_mainTex, uv).g;
    float colB = tex2D(_mainTex, float2(uv.x + (_offset.x * clamp(1 - (dist / _radius), 0, 1)), uv.y + (_offset.y * clamp(1 - (dist / _radius), 0, 1)))).b;

    return float4(colR, colG, colB, 1);
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 frag();
    }
}