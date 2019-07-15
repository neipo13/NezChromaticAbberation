using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticAbberation
{
    public class ChromaticAbberrationFieldPostProcessor : PostProcessor
    {
        public ChromaticAbberrationFieldPostProcessor(int executionOrder, Effect effect) : base(executionOrder, effect)
        {
            centerParam = effect.Parameters["_center"];
            offsetParam = effect.Parameters["_offset"];
            radiusParam = effect.Parameters["_radius"];

            centerParam.SetValue(center);
            offsetParam.SetValue(offset);
            radiusParam.SetValue(radius);
        }

        private EffectParameter centerParam;
        private EffectParameter offsetParam;
        private EffectParameter radiusParam;

        public Vector2 Center
        {
            get { return center; }
            set
            {
                center = value;
                centerParam?.SetValue(value);
            }
        }
        public Vector2 Offset
        {
            get { return offset; }
            set
            {
                offset = value;
                offsetParam?.SetValue(value);
            }
        }
        public float Radius
        {
            get { return radius; }
            set
            {
                radius = value;
                radiusParam?.SetValue(value);
            }
        }

        Vector2 center = new Vector2();
        Vector2 offset = new Vector2();
        float radius = 0f;
    }
}
