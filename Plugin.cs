using BepInEx;
using BepInEx.Configuration;
using DiskCardGame;
using HarmonyLib;
using InscryptionAPI.Ascension;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using System.Reflection;
using UnityEngine;

namespace KCTalkingCards
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {     
	    private const string PluginGuid = "rykedaxter.inscryption.kctalkingcards";
        private const string PluginName = "KCTalkingCards";
        private const string PluginVersion = "1.0.1";

        private ConfigEntry<bool> configTalkingCardsBalance;
        private static Harmony harmony;

        private void Awake()
        {            
            harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginGuid);

            configTalkingCardsBalance = Config.Bind("General",
                "TalkingCardsBalance",
                true,
                "Applies balancing to the talking cards when true and uses the original Part 1 values for the talking cards otherwise.");

            /* Add Cards and Decks */

            CardInfo KCTalkingCards_Stoat = Instantiate(CardLoader.GetCardByName("Stoat_Talking"))
                .SetNames("KCTalkingCards_Stoat", "Stoat")                
                .SetPixelPortrait(TextureHelper.GetImageAsTexture("Art.pixelportrait_stoat.png", Assembly.GetExecutingAssembly()));
            CardManager.Add(PluginName, KCTalkingCards_Stoat);
            CardInfo KCTalkingCards_Stinkbug = Instantiate(CardLoader.GetCardByName("Stinkbug_Talking"))
                .SetNames("KCTalkingCards_Stinkbug", "Stinkbug")                
                .SetPixelPortrait(TextureHelper.GetImageAsTexture("Art.pixelportrait_mealworm.png", Assembly.GetExecutingAssembly()));
            CardManager.Add(PluginName, KCTalkingCards_Stinkbug);
            CardInfo KCTalkingCards_Wolf = Instantiate(CardLoader.GetCardByName("Wolf_Talking"))
                .SetNames("KCTalkingCards_Wolf", "Stunted Wolf")
                .SetPixelPortrait(TextureHelper.GetImageAsTexture("Art.pixelportrait_wolf.png", Assembly.GetExecutingAssembly()));
            CardManager.Add(PluginName, KCTalkingCards_Wolf);

            StarterDeckInfo talkingCardsDeck = ScriptableObject.CreateInstance<StarterDeckInfo>();
            talkingCardsDeck.title = "Talking Cards";
            talkingCardsDeck.iconSprite = TextureHelper.GetImageAsTexture("Art.starterdeck_icon_vanilla.png", Assembly.GetExecutingAssembly()).ConvertTexture(TextureHelper.SpriteType.StarterDeckIcon, FilterMode.Point);
            talkingCardsDeck.cards = new() { CardLoader.GetCardByName("KCTalkingCards_Stoat"), CardLoader.GetCardByName("KCTalkingCards_Stinkbug"), CardLoader.GetCardByName("KCTalkingCards_Wolf") };
            StarterDeckManager.Add(PluginGuid, talkingCardsDeck);

            /* Apply Balance if Configured */

            if (configTalkingCardsBalance.Value) 
            {
                KCTalkingCards_Stoat.SetBaseAttackAndHealth(1, 2);
                KCTalkingCards_Stinkbug.SetBaseAttackAndHealth(0, 1);
                KCTalkingCards_Wolf.SetBaseAttackAndHealth(3, 2).SetBloodCost(2);
            }

            Logger.LogInfo($"Plugin {PluginName} {PluginVersion} is loaded!");            
        }

		private void OnDestroy()
		{
			harmony?.UnpatchSelf();
		}
    }
}