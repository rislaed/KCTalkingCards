using BepInEx;
using BepInEx.Bootstrap;
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
    [BepInDependency("cyantist.inscryption.api")]
    [BepInDependency(MycomergerGuid, BepInDependency.DependencyFlags.SoftDependency)]
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "rykedaxter.inscryption.kctalkingcards";
        public const string PluginName = "KCTalkingCards";
        public const string PluginVersion = "1.1.0";
        public const string MycomergerGuid = "rykedaxter.inscryption.mycomerger";

        private static ConfigEntry<bool> configTalkingCardsAppearInSeparateDeck;
        private static ConfigEntry<bool> configTalkingCardsAppearInCardChoices;
        private static ConfigEntry<bool> configTalkingCardsAreRare;
        private static ConfigEntry<bool> configTalkingCardsBalance;
        private static ConfigEntry<bool> configNontalkingStoatAppearsInCardChoices;
        private static ConfigEntry<bool> configTalkingCardsReplacesStarterDeck;
        private static ConfigEntry<bool> configTalkingCardsNontalkingMerge;
        private static ConfigEntry<string> configTalkingStoatCounterpart;
        private static ConfigEntry<string> configTalkingStinkbugCounterpart;
        private static ConfigEntry<string> configTalkingWolfCounterpart;

        private static Harmony harmony;

        private void Awake()
        {
            harmony = Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), PluginGuid);

            configTalkingCardsAppearInSeparateDeck = Config.Bind("General",
                "TalkingCardsAppearInSeparateDeck",
                false,
                "Talking Cards will occupy separate deck and can be selected if ascension is unlocked."
            );

            configTalkingCardsAppearInCardChoices = Config.Bind("General",
                "TalkingCardsAppearInCardChoices",
                true,
                "Talking Cards will show up in common card choices when true. Talking Cards are unique and if you already have one of a Talking Card in your deck, that Talking Card will not show up in card choices."
            );

            configTalkingCardsAreRare = Config.Bind("General",
                "TalkingCardsAreRare",
                false,
                "Talking Cards will be set as Rare. They will show up in Rare card choices and qualify as Rare for Rarity trials. You can have both this and TalkingCardsAppearInCardChoices active at the same time."
            );

            configTalkingCardsBalance = Config.Bind("General",
                "TalkingCardsBalance",
                true,
                "Applies balancing to the talking cards when true and uses the original Part 1 values for the talking cards otherwise."
            );

            configNontalkingStoatAppearsInCardChoices = Config.Bind("General",
                "NontalkingStoatAppearsInCardChoices",
                false,
                "The non-talking stoat card will appear in card choices when true."
            );

            configTalkingCardsReplacesStarterDeck = Config.Bind("General",
                "TalkingCardsReplacesStarterDeck",
                true,
                "Allows non-talking cards to be replaced with their talking counterparts in starter decks when true."
            );

            configTalkingCardsNontalkingMerge = Config.Bind("Mycologists",
                "TalkingCardsNontalkingMerge",
                false,
                "Allows talking cards to be merged with their non-talking counterparts at the Mycologists when true. Requires the MycoMerger mod."
            );

            configTalkingStoatCounterpart = Config.Bind("Mycologists",
                "TalkingStoatCounterpart",
                "Stoat",
                "The card name that designates the counterpart of the Talking Stoat for merging at the Mycologists. Default is \"Stoat\"."
            );

            configTalkingStinkbugCounterpart = Config.Bind("Mycologists",
                "TalkingStinkbugCounterpart",
                "RingWorm",
                "The card name that designates the counterpart of the Talking Stinkbug for merging at the Mycologists. Default is \"RingWorm\"."
            );

            configTalkingWolfCounterpart = Config.Bind("Mycologists",
                "TalkingWolfCounterpart",
                "Wolf",
                "The card name that designates the counterpart of the Talking Wolf for merging at the Mycologists. Default is \"Wolf\"."
            );

            /* Add Cards and Starter Deck */

            CardInfo InscryptionCards_Stoat = CardLoader.GetCardByName(configTalkingStoatCounterpart.Value);
            CardInfo KCTalkingCards_Stoat = Instantiate(CardLoader.GetCardByName("Stoat_Talking"))
                .SetNames("KCTalkingCards_Stoat", "Stoat")
                .SetPixelPortrait(InscryptionCards_Stoat?.pixelPortrait);
            CardManager.Add(PluginName, KCTalkingCards_Stoat);

            CardInfo InscryptionCards_Stinkbug = CardLoader.GetCardByName(configTalkingStinkbugCounterpart.Value);
            CardInfo KCTalkingCards_Stinkbug = Instantiate(CardLoader.GetCardByName("Stinkbug_Talking"))
                .SetNames("KCTalkingCards_Stinkbug", "Stinkbug")
                .SetPixelPortrait(InscryptionCards_Stinkbug?.pixelPortrait);
            CardManager.Add(PluginName, KCTalkingCards_Stinkbug);

            CardInfo InscryptionCards_Wolf = CardLoader.GetCardByName(configTalkingWolfCounterpart.Value);
            CardInfo KCTalkingCards_Wolf = Instantiate(CardLoader.GetCardByName("Wolf_Talking"))
                .SetNames("KCTalkingCards_Wolf", "Stunted Wolf")
                .SetPixelPortrait(InscryptionCards_Wolf?.pixelPortrait);
            CardManager.Add(PluginName, KCTalkingCards_Wolf);

            /* Apply Configuration */

            if (configTalkingCardsReplacesStarterDeck.Value)
			{
                foreach (var deck in StarterDeckManager.BaseGameDecks)
                {
                    if (deck.CardNames.Contains(configTalkingStoatCounterpart.Value))
                    {
                        deck.CardNames[deck.CardNames.IndexOf(configTalkingStoatCounterpart.Value)] = KCTalkingCards_Stoat.name;
                    }
                    if (deck.CardNames.Contains(configTalkingStinkbugCounterpart.Value))
                    {
                        deck.CardNames[deck.CardNames.IndexOf(configTalkingStinkbugCounterpart.Value)] = KCTalkingCards_Stinkbug.name;
                    }
                    if (deck.CardNames.Contains(configTalkingWolfCounterpart.Value))
                    {
                        deck.CardNames[deck.CardNames.IndexOf(configTalkingWolfCounterpart.Value)] = KCTalkingCards_Wolf.name;
                    }
                }
                StarterDeckManager.SyncDeckList();
			}

            if (configTalkingCardsAppearInSeparateDeck.Value)
            {
                StarterDeckInfo talkingCardsDeck = ScriptableObject.CreateInstance<StarterDeckInfo>();
                talkingCardsDeck.title = "Talking Cards";
                talkingCardsDeck.iconSprite = TextureHelper.GetImageAsTexture("Art.starterdeck_icon_kctalkingcards_talkingcards.png", Assembly.GetExecutingAssembly()).ConvertTexture(TextureHelper.SpriteType.StarterDeckIcon, FilterMode.Point);
                talkingCardsDeck.cards = [CardLoader.GetCardByName("KCTalkingCards_Stoat"), CardLoader.GetCardByName("KCTalkingCards_Stinkbug"), CardLoader.GetCardByName("KCTalkingCards_Wolf")];
                StarterDeckManager.Add(PluginGuid, talkingCardsDeck);
            }

            if (configTalkingCardsAppearInCardChoices.Value)
            {
                KCTalkingCards_Stoat.AddMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer);
                KCTalkingCards_Stinkbug.AddMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer);
                KCTalkingCards_Wolf.AddMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer);
            }

            if (configTalkingCardsAreRare.Value)
            {
                KCTalkingCards_Stoat.AddMetaCategories(CardMetaCategory.Rare);
                KCTalkingCards_Stinkbug.AddMetaCategories(CardMetaCategory.Rare);
                KCTalkingCards_Wolf.AddMetaCategories(CardMetaCategory.Rare);
            }

            if (configTalkingCardsBalance.Value)
            {
                KCTalkingCards_Stoat.SetBaseAttackAndHealth(1, 2);
                KCTalkingCards_Stinkbug.SetBaseAttackAndHealth(0, 1);
                KCTalkingCards_Wolf.SetBaseAttackAndHealth(3, 2).SetBloodCost(2);
            }

            if (configNontalkingStoatAppearsInCardChoices.Value)
            {
                CardLoader.GetCardByName("Stoat").AddMetaCategories(CardMetaCategory.ChoiceNode, CardMetaCategory.TraderOffer);
            }

            if (configTalkingCardsNontalkingMerge.Value)
            {
                if (Chainloader.PluginInfos.ContainsKey(MycomergerGuid))
                {
                    KCTalkingCards_Stoat.SetExtendedProperty("MycoMerger", $"{configTalkingStoatCounterpart.Value}:{KCTalkingCards_Stoat.name}");
                    KCTalkingCards_Stinkbug.SetExtendedProperty("MycoMerger", $"{configTalkingStinkbugCounterpart.Value}:{KCTalkingCards_Stinkbug.name}");
                    KCTalkingCards_Wolf.SetExtendedProperty("MycoMerger", $"{configTalkingWolfCounterpart.Value}:{KCTalkingCards_Wolf.name}");
                }
            }

        }

        private void OnDestroy()
        {
            harmony?.UnpatchSelf();
        }
    }
}