using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace InfiniteExpansion.Items
{
	public class FreezeZenith : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Fires a beam of time-stopping energy.\nStops all NPCs, Projectiles, and Items that touch it.");
		}

		public override void SetDefaults() {
			item.width = 28;
			item.height = 30;
			item.useTime = 20;
			item.UseSound = SoundID.Item12;
			item.useAnimation = 20;
			item.useStyle = 5;
			item.noMelee = true;
			item.rare = -11;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("Freeze");
			item.shootSpeed = 8f;
		}
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(-4, 0);
		}
		public override void HoldStyle(Player player)
		{
			player.itemLocation.X = player.Center.X + -2 * player.direction;
			player.itemLocation.Y = player.position.Y + 24;
		}
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/FreezeZenith_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}
