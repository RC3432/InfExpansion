 using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace InfiniteExpansion.Projectiles
{
	public class Shrink : ModProjectile
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
			DisplayName.SetDefault("Shrink");
			Main.projFrames[projectile.type] = 0;

		}
		public override void Kill(int timeLeft)
        {



		}
		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			projectile.scale *= 1.1f;
			projectile.alpha += 40;
			Lighting.AddLight(projectile.position, 1.0f, 2.0f, 2.0f);
			for (int a = 0; a < Main.maxNPCs; a++)
			{
					Item item = Main.item[a];
				if (projectile.Hitbox.Intersects(Main.item[a].Hitbox))
				{
					if (hit_item == false)
					{
						item.scale /= 2;
						item.height /= 2;
						item.width /= 2;
						item.damage /= 2;
						item.knockBack /= 2;
						item.useTime /= 2;
						item.useAnimation /= 2;
						item.crit /= 2;
						hit_item =  true;
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
					npc.scale /= 2;
					npc.height /= 2;
					npc.width /= 2;
					npc.damage /= 2;
					npc.knockBackResist *= 2;
					npc.lifeMax /= 2;
					npc.life /= 2;
						hit_npc = true;
                    }
                    else { }

				}

			}
			for (int c = 0; c < 1001; c++)
			{
				Projectile target = Main.projectile[c];
				if (target.type != projectile.type)
				{
					if (projectile.getRect().Intersects(target.getRect()))
					{
						if (hit_proj)
                        {
						target.scale /= 2;
						target.height /= 2;
						target.damage /= 2;
						target.penetrate /= 2;
						target.width /= 2;
							hit_proj = true;
                        }
                        else { }


					}
				}
			}
			



		}




	}
}
