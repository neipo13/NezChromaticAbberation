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
    public class ChromaticAbberationPostProcessor : PostProcessor
    {
        public ChromaticAbberationPostProcessor(int executionOrder, Effect effect): base(executionOrder, effect)
        {
            texelSizeParam = effect.Parameters["_texelSize"];
            offsetParam = effect.Parameters["_offset"];

            texelSizeParam.SetValue(texelSize);
            offsetParam.SetValue(offset);
        }

        private EffectParameter texelSizeParam;
        private EffectParameter offsetParam;
        public Vector2 TexelSize
        {
            get { return texelSize; }
            set
            {
                texelSize = value;
                texelSizeParam?.SetValue(value);
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


        Vector2 texelSize = new Vector2();
        Vector2 offset = new Vector2();
    }
}
