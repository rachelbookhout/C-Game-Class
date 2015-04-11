#region File Description
//-----------------------------------------------------------------------------
// ProgrammingAssignment5Game.cs
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
using System.Collections.Generic;
using TeddyMineExplosion;

#endregion

namespace ProgrammingAssignment5
{
	/// <summary>
	/// Default Project Template
	/// </summary>
	public class Game1 : Game
	{

		#region Fields

		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		const int WINDOW_WIDTH = 800;
		const int WINDOW_HEIGHT = 600;
		Texture2D mineSprite;
		List<Mine> mines = new List<Mine>();
		Texture2D teddySprite;
		List<TeddyBear> bears = new List<TeddyBear>();
		float timeuntilnextspawn;
		float timesincelastspawn;
		Random rand = new Random();
		bool leftClickStarted = false;
		bool leftButtonReleased = true;
		#endregion

		#region Initialization

		public Game1 ()
		{

			graphics = new GraphicsDeviceManager (this);
			
			Content.RootDirectory = "Assets";

			graphics.IsFullScreen = false;
			graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
			graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
			IsMouseVisible = true;


		

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
			mineSprite = Content.Load<Texture2D> ("mine");
			teddySprite = Content.Load<Texture2D> ("teddybear");
			// TODO: use this.Content to load your game content here eg.
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
			MouseState mouse = Mouse.GetState();
			//when left click is released, add mine to list of mines
			if (mouse.LeftButton == ButtonState.Pressed && leftButtonReleased) {
				leftClickStarted = true;
				leftButtonReleased = false;
			} else if (mouse.LeftButton == ButtonState.Released) 
			{
				leftButtonReleased = true;
			}
			if (leftClickStarted) {
				leftClickStarted = false;
				mines.Add (new Mine (mineSprite,mouse.X, mouse.Y));
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

			// draw mines
			foreach (Mine mine in mines) {
				mine.Draw (spriteBatch);
			}
			spriteBatch.End ();

			//TODO: Add your drawing code here
			base.Draw (gameTime);
		}

		#endregion
	}
}
