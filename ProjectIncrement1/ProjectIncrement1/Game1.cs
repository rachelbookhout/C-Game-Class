﻿#region File Description
//-----------------------------------------------------------------------------
// ProjectIncrement1Game.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GameProject
{
	/// <summary>
	/// This is the main type for your game
	/// </summary>
	public class Game1 : Microsoft.Xna.Framework.Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		public const int SPAWN_BORDER_SIZE = 100;
		int xlocation;
		int ylocation;
		float velocity;
		float angle;
		Vector2 vec;
		// game objects. Using inheritance would make this
		// easier, but inheritance isn't a GDD 1200 topic
		Burger burger;
		List<TeddyBear> bears = new List<TeddyBear>();
		static List<Projectile> projectiles = new List<Projectile>();
		List<Explosion> explosions = new List<Explosion>();

		// projectile and explosion sprites. Saved so they don't have to
		// be loaded every time projectiles or explosions are created
		static Texture2D frenchFriesSprite;
		static Texture2D teddyBearProjectileSprite;
		static Texture2D explosionSpriteStrip;

		// scoring support
		int score = 0;
		string scoreString = GameConstants.SCORE_PREFIX + 0;

		// health support
		string healthString = GameConstants.HEALTH_PREFIX + 
			GameConstants.BURGER_INITIAL_HEALTH;
		bool burgerDead = false;

		// text display support
		SpriteFont font;

		// sound effects
		SoundEffect burgerDamage;
		SoundEffect burgerDeath;
		SoundEffect burgerShot;
		SoundEffect explosion;
		SoundEffect teddyBounce;
		SoundEffect teddyShot;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Assets";

			// set resolution
			graphics.PreferredBackBufferWidth = GameConstants.WINDOW_WIDTH;
			graphics.PreferredBackBufferHeight = GameConstants.WINDOW_HEIGHT;
			IsMouseVisible = true;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			RandomNumberGenerator.Initialize();

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

			// load audio content

			// load sprite font
			burger = new Burger (Content,"burger",graphics.PreferredBackBufferWidth/2,graphics.PreferredBackBufferHeight * 7/8,null);
			SpawnBear ();
			// load projectile and explosion sprites
			teddyBearProjectileSprite = Content.Load<Texture2D>("teddybearprojectile") ;
			frenchFriesSprite = Content.Load<Texture2D>("frenchfries");
			// add initial game objects

			// set initial health and score strings
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// all content.
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


			// get current mouse state and update burger
			MouseState mouse = Mouse.GetState();
			burger.Update(gameTime, mouse);
			// update other game objects
			foreach (TeddyBear bear in bears)
			{
				bear.Update(gameTime);
			}
			foreach (Projectile projectile in projectiles)
			{
				projectile.Update(gameTime);
			}
			foreach (Explosion explosion in explosions)
			{
				explosion.Update(gameTime);
			}
			//check for a collision between each teddy bear and each
			//	projectile in the game. A reasonable approach would be to have a foreach loop over the bears list with a
			//		nested foreach loop over the projectiles list inside it. This will make sure you check every teddy
			//			bear/projectile pairing. In the inner loop, check to see if the current projectile is french fries (teddy bears
			//				don't kill teddy bears!) and the current teddy bear and the current projectile collide by checking if they're
			//				both active and if their collision rectangles intersect. If they do, set the Active property for the bear to
			//false and the Active property for the projectile to false.

			// check and resolve collisions between teddy bears

			// check and resolve collisions between burger and teddy bears

			// check and resolve collisions between burger and projectiles

			// check and resolve collisions between teddy bears and projectiles

			// clean out inactive teddy bears and add new ones as necessary

			// clean out inactive projectiles

			// clean out finished explosions

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			spriteBatch.Begin();

			// draw game objects
			burger.Draw(spriteBatch);
			foreach (TeddyBear bear in bears)
			{
				bear.Draw(spriteBatch);
			}
			foreach (Projectile projectile in projectiles)
			{
				projectile.Draw(spriteBatch);
			}
			foreach (Explosion explosion in explosions)
			{
				explosion.Draw(spriteBatch);
			}

			// draw score and health

			spriteBatch.End();

			base.Draw(gameTime);
		}

		#region Public methods

		/// <summary>
		/// Gets the projectile sprite for the given projectile type
		/// </summary>
		/// <param name="type">the projectile type</param>
		/// <returns>the projectile sprite for the type</returns>
		public static Texture2D GetProjectileSprite(ProjectileType type)
		{
			// replace with code to return correct projectile sprite based on projectile type
			if (type == ProjectileType.FrenchFries) {
				return frenchFriesSprite;
			} else if (type == ProjectileType.TeddyBear) {
				return teddyBearProjectileSprite;
			} else 
			{
				return null;
			}
			}

		/// <summary>
		/// Adds the given projectile to the game
		/// </summary>
		/// <param name="projectile">the projectile to add</param>
		public static void AddProjectile(Projectile projectile)
		{
			projectiles.Add(projectile);
		}

		#endregion

		#region Private methods

		/// <summary>
		/// Spawns a new teddy bear at a random location
		/// </summary>
		private void SpawnBear()
		{
			// generate random location
			xlocation = GetRandomLocation(SPAWN_BORDER_SIZE,graphics.PreferredBackBufferWidth - SPAWN_BORDER_SIZE *2 );
			ylocation = GetRandomLocation(SPAWN_BORDER_SIZE,graphics.PreferredBackBufferHeight - SPAWN_BORDER_SIZE*2);
			// generate random velocity
			velocity = GameConstants.MIN_BEAR_SPEED + RandomNumberGenerator.NextFloat(GameConstants.BEAR_SPEED_RANGE);
			angle = RandomNumberGenerator.NextFloat(2*(float)Math.PI);

			vec = new Vector2 (velocity * (float)Math.Cos(angle), velocity * (float)Math.Sin(angle));
			// create new bear
			TeddyBear newBear = new TeddyBear (Content,"teddybear",xlocation, ylocation,vec,null,null);
			// make sure we don't spawn into a collision

			// add new bear to list
			bears.Add (newBear);
		}

		/// <summary>
		/// Gets a random location using the given min and range
		/// </summary>
		/// <param name="min">the minimum</param>
		/// <param name="range">the range</param>
		/// <returns>the random location</returns>
		private int GetRandomLocation(int min, int range)
		{
			return min + RandomNumberGenerator.Next(range);
		}

		/// <summary>
		/// Gets a list of collision rectangles for all the objects in the game world
		/// </summary>
		/// <returns>the list of collision rectangles</returns>
		private List<Rectangle> GetCollisionRectangles()
		{
			List<Rectangle> collisionRectangles = new List<Rectangle>();
			collisionRectangles.Add(burger.CollisionRectangle);
			foreach (TeddyBear bear in bears)
			{
				collisionRectangles.Add(bear.CollisionRectangle);
			}
			foreach (Projectile projectile in projectiles)
			{
				collisionRectangles.Add(projectile.CollisionRectangle);
			}
			foreach (Explosion explosion in explosions)
			{
				collisionRectangles.Add(explosion.CollisionRectangle);
			}
			return collisionRectangles;
		}

		/// <summary>
		/// Checks to see if the burger has just been killed
		/// </summary>
		private void CheckBurgerKill()
		{

		}

		#endregion
	}
}
#endregion