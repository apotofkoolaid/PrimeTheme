using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimeTheme.Music
{
	public class SkeletronPrimeMusicScene : ModSceneEffect
	{
		//Enter the path to your music file here.
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Music/SkeletronPrime");

        //Enter a music priority here.
		//Ordered values are: BiomeLow, BiomeMedium, BiomeHigh, Environment, Event, BossLow, BossMedium, and BossHigh.
        public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        public override bool IsSceneEffectActive(Player player)
		{
            //Since this is a vanilla-style theme, I'm going to have this track be disabled when otherworldly music is on.
            bool otherworldlyMusicIsOff = Main.swapMusic == Main.drunkWorld;

            //Enter whatever conditions you're wanting for your song down here.
            return otherworldlyMusicIsOff && NPC.AnyNPCs(NPCID.SkeletronPrime) && Main.npc[NPC.FindFirstNPC(NPCID.SkeletronPrime)].Distance(player.Center) <= 8500f;
		}
	}
}
