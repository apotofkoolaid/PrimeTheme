using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace PrimeTheme.Tiles
{
	public class PrimeMusicBox : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileObsidianKill[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.Origin = new Point16(0, 1);
			TileObjectData.newTile.LavaDeath = false;
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Music Box");
			AddMapEntry(new Color(191, 142, 111), name);
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 48, ModContent.ItemType<Items.PrimeMusicBox>());
		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.cursorItemIconEnabled = true;
			player.cursorItemIconID = ModContent.ItemType<Items.PrimeMusicBox>();
		}

		public override bool CreateDust(int i, int j, ref int type)
		{
			return false;
		}

		public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
		{
			return true;
		}

		public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			if (Main.tile[i, j].TileFrameX == 36 && Main.tile[i, j].TileFrameY % 36 == 0 && (int)Main.timeForVisualEffects % 7 == 0 && Main._rand.Next(3) == 0)
			{
				int note = Main._rand.Next(570, 573);
				Vector2 position = new Vector2(i * 16 + 8, j * 16 - 8);
				Vector2 velocity = new Vector2(Main.WindForVisuals * 2f, -0.5f);
				velocity.X *= 1f + (float)Main._rand.Next(-50, 51) * 0.01f;
				velocity.Y *= 1f + (float)Main._rand.Next(-50, 51) * 0.01f;

				if (note == 572)
				{
					position.X -= 8f;
				}
				if (note == 571)
				{
					position.X -= 4f;
				}
				Gore.NewGore(new EntitySource_TileUpdate(i, j), position, velocity, note, 0.8f);
			}
		}
	}
}
