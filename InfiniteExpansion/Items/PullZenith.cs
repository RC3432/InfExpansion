using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using static Terraria.ModLoader.ModContent;

namespace InfiniteExpansion.Items
{
	public class PullZenith : ModItem
	{
		public override void SetStaticDefaults() {
			Tooltip.SetDefault("Drags nearby entities caught in the black-hole beam.");
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
			item.shoot = mod.ProjectileType("Pull");
			item.shootSpeed = 12f;
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

	}
}
