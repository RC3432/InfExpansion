 using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace InfiniteExpansion.Projectiles
{
	public class Freeze : ModProjectile
	{
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
			DisplayName.SetDefault("Freeze");
			Main.projFrames[projectile.type] = 0;

		}
		public override void Kill(int timeLeft)
        {



		}
		public override void AI()
		{
			projectile.scale *= 1.1f;
			projectile.alpha += 40;
			Lighting.AddLight(projectile.position, 2.55f, 2.49f, 1.81f);
			for (int a = 0; a < Main.maxNPCs; a++)
			{
					Item item = Main.item[a];
					if (projectile.Hitbox.Intersects(Main.item[a].Hitbox))
					{
					   ItemID.Sets.ItemNoGravity[item.type] = true;
					item.beingGrabbed = false;
				    }
					
		    }
			
			for (int b = 0; b < Main.maxNPCs; b++)
			{
				NPC npc = Main.npc[b];
				if (projectile.Hitbox.Intersects(Main.npc[b].Hitbox))
				{
					npc.aiStyle = 0;
					npc.noGravity = true;
					npc.damage = 0;
					npc.velocity = npc.velocity-npc.velocity;
				}

			}
			for (int c = 0; c < 1001; c++)
			{
				Projectile target = Main.projectile[c];
				if (target.type != projectile.type)
				{
					if (projectile.getRect().Intersects(target.getRect()))
					{
						target.velocity = target.velocity-target.velocity;
						target.damage = 0;
						
					}
				}
			}
			



		}




	}
}
