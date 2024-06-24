using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PrimeTheme.Music
{
	public class SkeletronPrimeMusicScene : ModSceneEffect
	{
		//Enter the path to your music file here.
		//Avoid using .wav files since they're generally discouraged for use in Terraria modding.
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Music/SkeletronPrime");

        //Enter the music priority here. Values are: BiomeLow, BiomeMedium, BiomeHigh, Environment, Event, BossLow, BossMedium, and BossHigh.
        //It typically looks like this:
        //public override SceneEffectPriority Priority => SceneEffectPriority.BossLow;

        //...but the popular Calamity Mod changes Skeletron Prime's music to Boss 3 when master and revengeance mode are active, so in this instance it looks like this:
        public override SceneEffectPriority Priority
        {
            get
            {
                var calamityMod = ModLoader.TryGetMod("CalamityMod", out Mod calamity);
                return Main.masterMode && (bool)calamity.Call("DifficultyActive", "revengeance") ? SceneEffectPriority.BossMedium : SceneEffectPriority.BossLow;
            }
        }

        public override bool IsSceneEffectActive(Player player)
		{
			//Enter whatever conditions you're wanting for your song down below.
			return NPC.AnyNPCs(NPCID.SkeletronPrime) && Main.npc[NPC.FindFirstNPC(NPCID.SkeletronPrime)].Distance(player.Center) <= 8500f;
		}
	}
}
