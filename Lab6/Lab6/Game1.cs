#region File Description
//-----------------------------------------------------------------------------
// Lab6Game.cs
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

#endregion

namespace Lab6
{
	/// <summary>
	/// Default Project Template
	/// </summary>
	public class Game1 : Game
	{

		#region Fields
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D logoTexture;
		Texture2D teddyBear1;
		Texture2D teddyBear2;
		Rectangle drawRectangle1;
		Rectangle drawRectangle2;

		#endregion

		#region Initialization

		public Game1 ()
		{
			const int WINDOW_WIDTH = 800;
			const int WINDOW_HEIGHT = 600;
			graphics = new GraphicsDeviceManager (this);

			graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
			graphics.PreferredBackBufferHeight = WINDOW_HEIGHT; 
			Content.RootDirectory = "Assets";

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
			teddyBear1 = Content.Load<Texture2D> ("teddybear0");
			teddyBear2 = Content.Load<Texture2D> ("teddybear1");
				drawRectangle1 = new Rectangle(
					graphics.PreferredBackBufferWidth/4,
					graphics.PreferredBackBufferHeight/4,
					teddyBear1.Width, teddyBear1.Height);
				drawRectangle2 = new Rectangle(graphics.PreferredBackBufferWidth/2,
					graphics.PreferredBackBufferHeight/2,
					teddyBear2.Width, teddyBear2.Height);
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

			// draw the logo
			spriteBatch.Draw (teddyBear1,drawRectangle1, Color.White);
			spriteBatch.Draw (teddyBear2,drawRectangle2, Color.White);
			spriteBatch.End ();

			//TODO: Add your drawing code here
			base.Draw (gameTime);
		}

		#endregion
	}
}
