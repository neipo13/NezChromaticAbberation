using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticAbberation
{
    public class GameScene : Scene
    {
        Entity entity;
        const float baseYPos = 45;

        ChromaticAbberationPostProcessor capp;
        ChromaticAbberrationMaterial cam;
        ChromaticAbberrationFieldPostProcessor cafpp;
        public override void initialize()
        {
            base.initialize();
            clearColor = Color.TransparentBlack;

            addRenderer(new DefaultRenderer());

            var texture = content.Load<Texture2D>("mazz");
            var bg = content.Load<Texture2D>("bg");
            var effect = content.Load<Effect>("effects/ChromaticAbberrationField");

            entity = new Entity();

            var sprite = new Sprite(texture);
            sprite.scale = new Vector2(0.25f);
            //cam = new ChromaticAbberrationMaterial(effect);
            //cam.TexelSize = new Vector2(1f / texture.Width, 1f / texture.Height); // A texel is a pixel within the size of the texture (not subtexture) as related to a 0-1 scale so for a 32x32 texture a texel size is 1/32
            //sprite.material = cam;
            entity.addComponent(sprite);

            entity.position = new Vector2(100, baseYPos);
            addEntity(entity);

            var bge = new Entity("background_entity");
            var bgs = bge.addComponent(new Sprite(bg));
            bgs.renderLayer = 100;
            bge.position = new Vector2(Game1.designWidth / 2, Game1.designHeight / 2);
            addEntity(bge);

            //capp = new ChromaticAbberationPostProcessor(1, effect);
            //capp.TexelSize = new Vector2(1f / Game1.designWidth, 1f / Game1.designHeight);
            //addPostProcessor(capp);
            cafpp = new ChromaticAbberrationFieldPostProcessor(0, effect);
            cafpp.Radius = 0.5f;
            addPostProcessor(cafpp);

        }

        public override void update()
        {
            base.update();
            entity.position = new Vector2(entity.position.X, baseYPos + (1.5f * Mathf.sin(Time.time * 3f)));

            //capp.Offset = new Vector2(2f * Mathf.sin(Time.time * 4f), 2f * Mathf.sin(Time.time * 2f));
            //cam.Offset = new Vector2(2f * Mathf.sin(Time.time * 4f), 4f * Mathf.sin(Time.time * 2f));

            cafpp.Offset = new Vector2((2f / Game1.designWidth) * Mathf.sin(Time.time * 4f), (2f / Game1.designHeight) * Mathf.sin(Time.time * 2f));
            cafpp.Center = new Vector2(entity.position.X / Game1.designWidth, entity.position.Y / Game1.designHeight);
        }
    }
}
