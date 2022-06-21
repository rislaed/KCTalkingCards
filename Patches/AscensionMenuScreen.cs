using DiskCardGame;
using HarmonyLib;
using KCTalkingCards.util;

namespace KCTalkingCards.Patches
{

	[HarmonyPatch(typeof(AscensionMenuScreens), "Awake")]
	class AscensionMenuScreensAwakePatch
    {
		[HarmonyPostfix]
		static void AscensionMenuScreensAwake()
		{			
			MenuChecker.InMenuToTrue();
		}
	}

	[HarmonyPatch(typeof(AscensionMenuScreens), "TransitionToGame")]
	class AscensionMenuScreensTransitionToGamePatch
	{
		[HarmonyPostfix]
		static void AscensionMenuScreensTransitionToGame()
		{
			MenuChecker.InMenuToFalse();			
		}
	}	
}
