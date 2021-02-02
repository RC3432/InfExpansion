 using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.ModLoader;

namespace InfiniteExpansion.Projectiles
{
	public class Heal : ModProjectile
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
			DisplayName.SetDefault("Heal");
			Main.projFrames[projectile.type] = 0;

		}
		public override void Kill(int timeLeft)
        {



		}
		public override void AI()
		{
			projectile.scale *= 1.1f;
			projectile.alpha += 40;
			Lighting.AddLight(projectile.position, 0.0f, 2.0f, 0.0f);
			
			for (int b = 0; b < Main.maxNPCs; b++)
			{
				NPC npc = Main.npc[b];
				if (projectile.Hitbox.Intersects(Main.npc[b].Hitbox))
				{
					if (npc.lifeMax > npc.life)
                    {
						npc.HealEffect(npc.lifeMax - npc.life, true);
						npc.life += npc.lifeMax - npc.life;
						if (npc.life > npc.lifeMax)
                        {
							npc.life = npc.lifeMax;
                        }
                    }
				}

			}
			for (int d = 0; d < Main.maxNPCs; d++)
			{
				Player player = Main.player[d];
				if (projectile.Hitbox.Intersects(Main.player[d].Hitbox))
				{
			        if (player.statLife < player.statLifeMax)
                    {
						player.HealEffect(player.statLifeMax - player.statLife, true);
						player.statLife += player.statLifeMax - player.statLife;
						if (player.statLife > player.statLifeMax)
                        {
							player.statLife = player.statLifeMax;
                        }


					}
				}

			}




		}




	}
}
