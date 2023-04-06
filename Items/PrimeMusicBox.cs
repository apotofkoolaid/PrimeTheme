using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Utilities;
using Terraria.Localization;

namespace PrimeTheme.Items
{
	public class PrimeMusicBox : ModItem
	{
		public override LocalizedText DisplayName => Language.GetOrRegister("Music Box (Skeletron Prime)");

		public override void SetStaticDefaults()
		{
			Item.ResearchUnlockCount = 1;

			if (!Main.dedServ)
			{
				MusicLoader.AddMusicBox(Mod, MusicLoader.GetMusicSlot(Mod, "Music/SkeletronPrime"), ModContent.ItemType<Items.PrimeMusicBox>(), ModContent.TileType<Tiles.PrimeMusicBox>());
			}
		}

		public override void SetDefaults()
		{
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTurn = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.autoReuse = true;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<Tiles.PrimeMusicBox>();
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.LightRed;
			Item.value = 100000;
			Item.accessory = true;
		}

		public override bool? PrefixChance(int pre, UnifiedRandom rand)
		{
			if (this != null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
