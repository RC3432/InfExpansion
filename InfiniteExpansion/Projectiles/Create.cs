 using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace InfiniteExpansion.Projectiles
{
	public class Create : ModProjectile
	{
		bool hit_npc = false;
		bool hit_item = false;
		bool hit_proj = false;
		
		public override void SetDefaults()
		{

			projectile.width = 96;
			projectile.height = 96;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.aiStyle = 1;
			aiType = 14;
			projectile.hostile = false;
			projectile.alpha = 0;
			projectile.timeLeft = 15;
			projectile.light = 0.0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Create");
			Main.projFrames[projectile.type] = 0;

		}
		public override void Kill(int timeLeft)
        {



		}
		public override void AI()
		{
			projectile.scale *= 1.1f;
			projectile.alpha += 40;
			Lighting.AddLight(projectile.position, 2.0f, 2.0f, 0.0f);
			for (int a = 0; a < Main.maxNPCs; a++)
			{
					Item item = Main.item[a];
					if (projectile.Hitbox.Intersects(Main.item[a].Hitbox))
					{
					if (hit_item == false)
                    {
						hit_item = true;
					item.active = false;
					Item.NewItem(item.position, Main.rand.Next(1, 3929), item.stack);
                    }
					else
                    {

                    }
					
				}
		    }
			
			for (int b = 0; b < Main.maxNPCs; b++)
			{
				NPC npc = Main.npc[b];
				if (projectile.Hitbox.Intersects(Main.npc[b].Hitbox))
				{
					if (hit_npc == false)
                    {
				npc.active = false;
					int bre = NPC.NewNPC((int)npc.position.X,(int)npc.position.Y, Main.rand.Next(1, 579));
					Main.npc[bre].velocity = npc.velocity;
						hit_npc = true;
                    }
					else
                    {

                    }
	
				}

			}
			for (int c = 0; c < 1001; c++)
			{
				Projectile target = Main.projectile[c];
				if (target.type != projectile.type)
				{
					if (projectile.getRect().Intersects(target.getRect()))
					{
						if (hit_proj == false)
                        {
						target.active = false;
						int bree = NPC.NewNPC((int)target.position.X, (int)target.position.Y, Main.rand.Next(1, 713));
						Main.projectile[bree].velocity = target.velocity;
							hit_proj = true;
                        }
                        else
                        {

                        }



					}
				}
			}
			{
				int explosionRadius = 3;
					explosionRadius = 4;
				
				int minTileX = (int)(projectile.position.X / 16f - (float)explosionRadius);
				int maxTileX = (int)(projectile.position.X / 16f + (float)explosionRadius);
				int minTileY = (int)(projectile.position.Y / 16f - (float)explosionRadius);
				int maxTileY = (int)(projectile.position.Y / 16f + (float)explosionRadius);
				if (minTileX < 0)
				{
					minTileX = 0;
				}
				if (maxTileX > Main.maxTilesX)
				{
					maxTileX = Main.maxTilesX;
				}
				if (minTileY < 0)
				{
					minTileY = 0;
				}
				if (maxTileY > Main.maxTilesY)
				{
					maxTileY = Main.maxTilesY;
				}
				bool canKillWalls = false;
				for (int x = minTileX; x <= maxTileX; x++)
				{
					for (int y = minTileY; y <= maxTileY; y++)
					{
						float diffX = Math.Abs((float)x - projectile.position.X / 16f);
						float diffY = Math.Abs((float)y - projectile.position.Y / 16f);
						double distance = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
						if (distance < (double)explosionRadius && Main.tile[x, y] != null && Main.tile[x, y].wall == 0)
						{
							canKillWalls = true;
							break;
						}
					}
				}
				for (int i = minTileX; i <= maxTileX; i++)
				{
					for (int j = minTileY; j <= maxTileY; j++)
					{
						float diffX = Math.Abs((float)i - projectile.position.X / 16f);
						float diffY = Math.Abs((float)j - projectile.position.Y / 16f);
						double distanceToTile = Math.Sqrt((double)(diffX * diffX + diffY * diffY));
						if (distanceToTile < (double)explosionRadius)
						{
							bool canKillTile = true;
							if (Main.tile[i, j] != null && Main.tile[i, j].active())
							{
								canKillTile = true;
								if (Main.tileDungeon[(int)Main.tile[i, j].type] || Main.tile[i, j].type == 88 || Main.tile[i, j].type == 21 || Main.tile[i, j].type == 26 || Main.tile[i, j].type == 107 || Main.tile[i, j].type == 108 || Main.tile[i, j].type == 111 || Main.tile[i, j].type == 226 || Main.tile[i, j].type == 237 || Main.tile[i, j].type == 221 || Main.tile[i, j].type == 222 || Main.tile[i, j].type == 223 || Main.tile[i, j].type == 211 || Main.tile[i, j].type == 404)
								{
									canKillTile = true;
								}
								if (!Main.hardMode && Main.tile[i, j].type == 58)
								{
									canKillTile = true;
								}
								if (!TileLoader.CanExplode(i, j))
								{
									canKillTile = true;
								}
								if (canKillTile)
								{

									WorldGen.PlaceTile(i, j, Main.rand.Next(1, 469));
									WorldGen.KillWire(i, j);
									WorldGen.KillActuator(i, j);
									if (!Main.tile[i, j].active() && Main.netMode != NetmodeID.SinglePlayer)
									{
										NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, (float)i, (float)j, 0f, 0, 0, 0);
									}
								}
							}
							if (canKillTile)
							{
								for (int x = i - 1; x <= i + 1; x++)
								{
									for (int y = j - 1; y <= j + 1; y++)
									{
										if (Main.tile[x, y] != null && Main.tile[x, y].wall > 0 && canKillWalls && WallLoader.CanExplode(x, y, Main.tile[x, y].wall))
										{
											WorldGen.PlaceWall(x, y, Main.rand.Next(1, 230));
											if (Main.tile[x, y].wall == 0 && Main.netMode != NetmodeID.SinglePlayer)
											{
												NetMessage.SendData(MessageID.TileChange, -1, -1, null, 2, (float)x, (float)y, 0f, 0, 0, 0);
											}
										}
									}
								}
							}
						}
					}
				}
			}



		}




	}
}
