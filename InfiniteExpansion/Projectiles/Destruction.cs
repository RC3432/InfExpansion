 using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace InfiniteExpansion.Projectiles
{
	public class Destruction : ModProjectile
	{
		public override void SetDefaults()
		{

			projectile.width = 128;
			projectile.height = 128;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.aiStyle = 1;
			aiType = 14;
			projectile.hostile = false;
			projectile.alpha = 0;
			projectile.timeLeft = 30;
			projectile.light = 0.0f;
		}

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Destruction");
			Main.projFrames[projectile.type] = 0;

		}
		public override void Kill(int timeLeft)
        {



		}
		public override void AI()
		{
			projectile.alpha += 20;
			projectile.scale *= 1.1f;
			Lighting.AddLight(projectile.position, 2.0f, 0.0f, 0.0f);
			for (int a = 0; a < Main.maxNPCs; a++)
			{
				Item item = Main.item[a];
					item.active = false;
				int numberProjectilese = Main.rand.Next(7, 17);
				for (int i = 0; i < numberProjectilese; i++)
				{
					int num138 = Dust.NewDust(item.position, item.width, item.height, 235, 0 + Main.rand.Next(-8, 8), 0 + Main.rand.Next(-8, 8), 100);
				}
			}
			for (int b = 0; b < Main.maxNPCs; b++)
			{
					NPC npc = Main.npc[b];
				int numberProjectilese = Main.rand.Next(16, 43);
				for (int i = 0; i < numberProjectilese; i++)
				{
					int num138 = Dust.NewDust(npc.position, npc.width, npc.height, 235, 0 + Main.rand.Next(-8, 8), 0 + Main.rand.Next(-8, 8), 100);
				}
				npc.active = false;

			}
			for (int c = 0; c < 1001; c++)
			{
				Projectile target = Main.projectile[c];
				if (target.type != projectile.type)
				{
						target.active = false;
					int numberProjectilese = Main.rand.Next(7, 17);
					for (int i = 0; i < numberProjectilese; i++)
					{
						int num138 = Dust.NewDust(target.position, target.width, target.height, 235, 0 + Main.rand.Next(-8, 8), 0 + Main.rand.Next(-8, 8), 100);
					}

				}
			}


		}




	}
}
