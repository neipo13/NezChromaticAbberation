sampler _mainTex;
float2 _texelSize;
float2 _offset;

float4 frag(float2 uv : TEXCOORD0) : COLOR0
{
    //basically just move blue and red in opposite ways
    float colR = tex2D(_mainTex, float2(uv.x - (_offset.x * _texelSize.x), uv.y - (_offset.y * _texelSize.y))).r;
    float colG = tex2D(_mainTex, uv).g;
    float colB = tex2D(_mainTex, float2(uv.x + (_offset.x * _texelSize.x), uv.y + (_offset.y * _texelSize.y))).b;

    return float4(colR, colG, colB, 1);
}

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 frag();
    }
}