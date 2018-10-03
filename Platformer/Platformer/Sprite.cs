using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    public class Sprite
    {
        public Vector2 position = Vector2.Zero;
        public Vector2 velocity = Vector2.Zero;
        public Vector2 offset = Vector2.Zero;

        Texture2D texture;

        public int width = 0;
        public int height = 0;

        //The edges of the sprite are also the edges of the hitbox for collision
        public int leftEdge = 0;
        public int rightEdge = 0;
        public int topEdge = 0;
        public int bottomEdge = 0;

        public Sprite()
        {

        }

        public void Load(ContentManager content, string asset, bool useOffset)
        {
            texture = content.Load<Texture2D>(asset);
            width = texture.Bounds.Width;
            height = texture.Bounds.Height;

            if (useOffset == true)
            {
                offset = new Vector2(leftEdge + width / 2, topEdge + height / 2);
            }

            UpdateHitBox();
        }

        public void UpdateHitBox()
        {
            leftEdge = (int)position.X;
            rightEdge = (int)position.X + width;
            topEdge = (int)position.Y;
            bottomEdge = (int)position.Y + height;
        }

        public void Update(float deltaTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position - offset, Color.White);



        }
    }
}
