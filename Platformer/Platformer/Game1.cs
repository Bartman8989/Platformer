using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Tiled;
using MonoGame.Extended.Tiled.Graphics;
using MonoGame.Extended.ViewportAdapters;

namespace Platformer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player = new Player(); //Create an instance of our player class

        Camera2D camera = null; //Create an instance of a 2D Camera
        TiledMap map = null; //Creates an instance of a Tiled map
        TiledMapRenderer mapRenderer = null; //Creates an instance ofwhat makes a Tiled map

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.Load(Content, this); // Call the 'Load' function in the Player class
            //'this' basically means "pass all information in our class through as a variable"

            BoxingViewportAdapter viewportAdapter = new BoxingViewportAdapter(Window,GraphicsDevice, graphics.GraphicsDevice.Viewport.Width, graphics.GraphicsDevice.Viewport.Height);
            camera = new Camera2D(viewportAdapter);
            camera.Position = new Vector2(0, graphics.GraphicsDevice.Viewport.Height);

            map = Content.Load<TiledMap>("Level1");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);

            map = Content.Load<TiledMap>("Level1");
            mapRenderer = new TiledMapRenderer(GraphicsDevice);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            player.Update(deltaTime); // Call the 'Update' from our Player class

            camera.Position = player.playerSprite.position - new Vector2(graphics.GraphicsDevice.Viewport.Width / 2, graphics.GraphicsDevice.Viewport.Height / 2);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        
        
        
        protected override void Draw(GameTime gameTime)
        {
            // CLear anything previously drawn to the screen
            GraphicsDevice.Clear(Color.Gray);

            var viewMatrix = camera.GetViewMatrix();
            var projectionMatrix = Matrix.CreateOrthographicOffCenter(0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, 0, 0.0f, -1.0f);



            //Begin drawing
            spriteBatch.Begin(transformMatrix: viewMatrix);



            mapRenderer.Draw(map, ref viewMatrix, ref projectionMatrix);
            // Call the 'Draw' function from Player class
            player.Draw(spriteBatch);
            //Finish drawing
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
