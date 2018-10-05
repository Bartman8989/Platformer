using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Platformer
{
    public class Chest
    {

        public Sprite chestSprite = new Sprite();
        Collision collision = new Collision();
        Game1 game = null;

        public void Load (ContentManager content, Game1 theGame)
        {
            game = theGame;

            AnimatedTexture animation = new AnimatedTexture(Vector2.Zero, 0, 1, 1);
            animation.Load(content, "chest", 1, 1);

            chestSprite.AddAnimation(animation, 0, 3);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            chestSprite.Draw(spriteBatch);
        }

    }
}
