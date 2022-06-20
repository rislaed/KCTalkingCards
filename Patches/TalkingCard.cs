using DiskCardGame;
using HarmonyLib;
using System.Linq;

namespace KCTalkingCards
{
	[HarmonyPatch(typeof(TalkingCard), "OnDrawn")]
	class AscensionTalkingCardPatch
	{
		[HarmonyPrefix]
		static bool AscensionOnDrawn(TalkingCard __instance)
		{
			if (SaveFile.IsAscension)
			{
				string[] talkingCardsToSkipOnDrawn = { "DiskCardGame.StoatTalkingCard", "DiskCardGame.StinkbugTalkingCard", "DiskCardGame.WolfTalkingCard" };

				if (talkingCardsToSkipOnDrawn.Contains(__instance.GetType().ToString()))
				{
					return false;
				}
			}
			return true;
		}
	}
}