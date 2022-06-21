using DiskCardGame;
using HarmonyLib;
using UnityEngine;
using System.Linq;

namespace KCTalkingCards.Patches
{
    [HarmonyPatch(typeof(CardInfo), "AnimatedPortrait", MethodType.Getter)] 
	class AscensionAnimatedPortraitPatch
    {
		[HarmonyPrefix]
		static bool AscensionAnimatedPortrait(ref GameObject __result, CardInfo __instance, GameObject ___animatedPortrait)
		{
			if (SaveFile.IsAscension)
			{
				string[] cardsToUseBaseAnimatedPortrait = { "KCTalkingCards_Stoat", "KCTalkingCards_Stinkbug", "KCTalkingCards_Wolf" };

                if(cardsToUseBaseAnimatedPortrait.Contains(__instance.name))
				{
					__result = ___animatedPortrait;
					return false;
				}
			}
			return true;
		}
	}
}