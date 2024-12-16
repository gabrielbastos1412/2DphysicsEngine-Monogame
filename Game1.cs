using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Flat;
using Flat.Graphics;

namespace teste
{
    public class Game1 : Game
    {
        //global things
        private SpriteBatch sprites1;
        private GraphicsDeviceManager graphics;
        private Sprites sprites;
        private Texture2D texture;
        private Screen screen;
        private RenderTarget2D renderTarget;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.SynchronizeWithVerticalRetrace = true;
            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            this.IsFixedTimeStep = true;
        }

        protected override void Initialize()
        {
            this.graphics.PreferredBackBufferWidth = 1920;
            this.graphics.PreferredBackBufferHeight = 1080;
            this.graphics.ApplyChanges();

            this.sprites = new Sprites(this);
            this.screen = new Screen(this, 640, 480);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sprites1 = new SpriteBatch(this.GraphicsDevice);
            this.texture = this.Content.Load<Texture2D>("ball");
            this.renderTarget = new RenderTarget2D(this.GraphicsDevice, 640, 480);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.screen.Set();
            //this.GraphicsDevice.SetRenderTarget(this.renderTarget);
            this.GraphicsDevice.Clear(Color.CornflowerBlue);

            //Viewport vp = this.GraphicsDevice.Viewport;

            this.sprites.Begin(false);
            this.sprites.Draw(texture,null, new Rectangle(32,32,128,128), Color.White);
            this.sprites.End();

            //this.GraphicsDevice.SetRenderTarget(null);

            //this.screen.UnSet();
            //GraphicsDevice.Clear(Color.CornflowerBlue);
            //this.sprites.Begin(false);
            //this.sprites.Draw(screen.get(), null, new Rectangle(30,30,256,512), Color.White);
            //this.sprites.End();

            this.screen.UnSet();
            this.screen.Present(this.sprites);

            base.Draw(gameTime);
        }
    }
}
