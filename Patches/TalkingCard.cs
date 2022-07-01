using DiskCardGame;
using HarmonyLib;
using KCTalkingCards.util;
using System.Linq;

namespace KCTalkingCards.Patches
{
	[HarmonyPatch]
	class AscensionTalkingCardPatch
	{
		[HarmonyPatch(typeof(TalkingCard), "OnDrawn")]
		[HarmonyPrefix]
		static bool AscensionTalkingCardOnDrawn(TalkingCard __instance)
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

		[HarmonyPatch(typeof(TalkingCard), "Start")]
		[HarmonyPrefix]
		static bool AscensionTalkingCardStart()
		{
			if (SaveFile.IsAscension)
			{
				if (MenuChecker.InMenu)
				{
					return false;
				}
			}
			return true;
		}
	}
}