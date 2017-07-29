using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LD39.Managers
{

    public enum FontSize { Small, Medium, Large }

    public class GraphicsManager
    {

        public static GraphicsManager Instance { get; } = new GraphicsManager();

        private GraphicsManager() { }

        public Camera cam { get; set; }

        private SpriteBatch spriteBatch;

        /// <summary>
        /// Init function, used for assigning the spritebatch
        /// </summary>
        /// <param name="spriteBatch">A refrence to the spritebatch in our game class</param>
        public void Init(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }
        
        /// <summary>
        /// Draws a sprite
        /// </summary>
        /// <param name="sprite">The sprite to draw</param>
        /// <param name="position">Where to draw it</param>
        /// <param name="color">What color to draw it in - if White it will be the colors of the img</param>
        public void DrawSprite(Texture2D sprite, Vector2 position, Color color, bool ui)
        {
            if(ui)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, position, color);
                spriteBatch.End();
            }
            else if (cam != null)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
                spriteBatch.Draw(sprite, position, color);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, position, color);
                spriteBatch.End();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprite">The sprite to draw</param>
        /// <param name="position">Where to draw it</param>
        /// <param name="sourceRect">A rectangle to define a smaller area of the sprite - Used for spritesheet and animations</param>
        /// <param name="color">What color to draw it in - if White it will be the colors of the img</param>
        public void DrawSprite(Texture2D sprite, Vector2 position, Rectangle sourceRect, Color color, bool ui)
        {
            if(ui)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sourceRect.Width, sourceRect.Height), sourceRect, color);
                spriteBatch.End();
            }
            else if (cam != null)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
                spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sourceRect.Width, sourceRect.Height), sourceRect, color);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, sourceRect.Width, sourceRect.Height), sourceRect, color);
                spriteBatch.End();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprite">The sprite to draw</param>
        /// <param name="destinationRect">Where to draw it</param>
        /// <param name="sourceRect">A rectangle to define a smaller area of the sprite - Used for spritesheet and animations</param>
        /// <param name="color">What color to draw it in - if White it will be the colors of the img</param>
        public void DrawSprite(Texture2D sprite, Rectangle destinationRect, Rectangle sourceRect, Color color, bool ui)
        {
            if(ui)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, destinationRect, sourceRect, color);
                spriteBatch.End();
            }
            else if (cam != null)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
                spriteBatch.Draw(sprite, destinationRect, sourceRect, color);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, destinationRect, sourceRect, color);
                spriteBatch.End();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprite">The sprite to draw</param>
        /// <param name="destinationRect">Where to draw it</param>
        /// <param name="sourceRect">A rectangle to define a smaller area of the sprite - Used for spritesheet and animations</param>
        /// <param name="color">What color to draw it in - if White it will be the colors of the img</param>
        public void DrawSprite(Texture2D sprite, Rectangle destinationRect, Color color, bool ui)
        {
            if(ui)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, destinationRect, null, color);
                spriteBatch.End();
            }
            else if (cam != null)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
                spriteBatch.Draw(sprite, destinationRect, null, color);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, destinationRect, null, color);
                spriteBatch.End();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sprite">The sprite to draw</param>
        /// <param name="destinationRect">Where to draw it</param>
        /// <param name="sourceRect">A rectangle to define a smaller area of the sprite - Used for spritesheet and animations</param>
        /// <param name="color">What color to draw it in - if White it will be the colors of the img</param>
        public void DrawSprite(Texture2D sprite, Rectangle destinationRect, Color color, float rotation, Vector2 origin, bool ui)
        {
            rotation += MathHelper.ToRadians(90);
            if (ui)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, destinationRect, null, color, rotation, origin, SpriteEffects.None, 0f);
                spriteBatch.End();
            }
            else if (cam != null)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null, cam.GetViewMatrix());
                spriteBatch.Draw(sprite, destinationRect, null, color, rotation, origin, SpriteEffects.None, 0f);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, null, SamplerState.PointClamp, null, null, null);
                spriteBatch.Draw(sprite, destinationRect, null, color, rotation, origin, SpriteEffects.None, 0f);
                spriteBatch.End();
            }
        }
    }
}
