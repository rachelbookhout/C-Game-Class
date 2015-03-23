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
		Explosion explosion;
		Random random = new Random();
		Texture2D teddybear;
		Texture2D boom;
		int x;
		int y;
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
			bear.Update();
			explosion.Update(gameTime);		
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
