#region File Description
//-----------------------------------------------------------------------------
// Lab11Game.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using ExplodingTeddies;

#endregion

namespace Lab11
{
	/// <summary>
	/// Default Project Template
	/// </summary>
	public class Game1 : Game
	{

		#region Fields
		public const int WINDOW_WIDTH = 800;
		public const int WINDOW_HEIGHT = 600;
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		TeddyBear bear;
		TeddyBear bear1;
		Explosion explosion;
		Random random = new Random();

		int x;
		int y;
		//MouseState mouseState;

		#endregion

		#region Initialization

		public Game1 ()
		{

			graphics = new GraphicsDeviceManager (this);
			
			Content.RootDirectory = "Assets";
			graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
			graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
			IsMouseVisible = true;
			graphics.IsFullScreen = false;

		}

		/// <summary>
		/// Overridden from the base Game.Initialize. Once the GraphicsDevice is setup,
		/// we'll use the viewport to initialize some values.
		/// </summary>
		protected override void Initialize ()
		{
			base.Initialize ();
		}


		/// <summary>
		/// Load your graphics content.
		/// </summary>
		protected override void LoadContent ()
		{
			// Create a new SpriteBatch, which can be use to draw textures.
			spriteBatch = new SpriteBatch (graphics.GraphicsDevice);
			// TODO: use this.Content to load your game content here eg.
			bear = new TeddyBear (Content, WINDOW_WIDTH,
				WINDOW_HEIGHT, "teddybear0", random.Next(-4,5), 
				random.Next(-4,5),   
				new Vector2(random.Next(-4, 5), random.Next(-4, 5)));
			explosion = new Explosion(Content);	
		}

		#endregion

		#region Update and Draw

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update (GameTime gameTime)
		{
			// TODO: Add your update logic here	
			//MouseState mouseState = Mouse.GetState();
			bear.Update();
			explosion.Update(gameTime);	
			//if (bear.Active && 
			//	mouseState.LeftButton == ButtonState.Pressed &&
			//	bear.DrawRectangle.Contains (mouseState.X, mouseState.Y))
			//{
			//	bear.Active = false;
			//	explosion.Play(bear.DrawRectangle.Center.X, bear.DrawRectangle.Center.Y);
			//}
			Rectangle rectangleBear = bear.DrawRectangle;


			// spawn new bear if A is pressed
			KeyboardState keyboard = Keyboard.GetState();
			if (keyboard.IsKeyDown(Keys.A))
			{
				// Load Teddybear
				int speedX = random.Next(-5, 5);
				int speedY = random.Next(-5, 5);
				Vector2 bearVector = new Vector2(speedX, speedY);
				bear = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear0", WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2, bearVector);
			}

			// explode bear if B is pressed
			if (keyboard.IsKeyDown (Keys.B)) {
				// set explosion location
				int explosionX = rectangleBear.X + (rectangleBear.Width / 2);
				int explosionY = rectangleBear.Y + (rectangleBear.Height / 2);

				// explode bear
				explosion.Play (bear.DrawRectangle.Center.X, bear.DrawRectangle.Center.Y);
				bear.Active = false;
			}
			else if(!bear.Active){

				// Load bear
				int speedX = random.Next(-5, 5);
				int speedY = random.Next(-5, 5);
				Vector2 bear1Vector = new Vector2(speedX, speedY);
				bear1 = new TeddyBear(Content, WINDOW_WIDTH, WINDOW_HEIGHT, "teddybear1", WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2, bear1Vector);
			}
			
			base.Update (gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself. 
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw (GameTime gameTime)
		{
			// Clear the backbuffer
			graphics.GraphicsDevice.Clear (Color.CornflowerBlue);

			spriteBatch.Begin ();

			bear.Draw (spriteBatch);
			explosion.Draw (spriteBatch);
			spriteBatch.End ();

			//TODO: Add your drawing code here
			base.Draw (gameTime);
		}

		#endregion
	}
}
