using DiskCardGame;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KCTalkingCards.Patches
{
    [HarmonyPatch]
    class AscensionDuplicateMergeSequencerPatch
    {
        [HarmonyPatch(typeof(DuplicateMergeSequencer), "GetValidDuplicateCards")]
        [HarmonyPostfix]
        private static void AddValidTalkingDuplicates(ref List<CardInfo> __result)
        {
            if (SaveFile.IsAscension && KCTalkingCards.Plugin.talkingCardsNontalkingMergeFlag)
            {
                List<CardInfo> modifiedList = new();
                Dictionary<string, List<CardInfo>> dictionary = new();
                Dictionary<string, string> kcHostMergeDict = new();
                Dictionary<string, string> kcDuplicateMergeDict = new();

                kcHostMergeDict.Add("KCTalkingCards_Stoat", KCTalkingCards.Plugin.talkingStoatCounterpart);
                kcHostMergeDict.Add("KCTalkingCards_Stinkbug", KCTalkingCards.Plugin.talkingStinkbugCounterpart);
                kcHostMergeDict.Add("KCTalkingCards_Wolf", KCTalkingCards.Plugin.talkingWolfCounterpart);

                kcDuplicateMergeDict.Add(KCTalkingCards.Plugin.talkingStoatCounterpart, "KCTalkingCards_Stoat");
                kcDuplicateMergeDict.Add(KCTalkingCards.Plugin.talkingStinkbugCounterpart, "KCTalkingCards_Stinkbug");
                kcDuplicateMergeDict.Add(KCTalkingCards.Plugin.talkingWolfCounterpart, "KCTalkingCards_Wolf");

                using (List<CardInfo>.Enumerator enumerator = RunState.DeckList.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        CardInfo card = enumerator.Current;
                        if (kcHostMergeDict.ContainsKey(card.name) && RunState.DeckList.Any((CardInfo x) => x.name.Equals(kcHostMergeDict[card.name])))
                        {
                            if (!dictionary.ContainsKey(card.name))
                            {
                                dictionary.Add(card.name, new List<CardInfo>());
                            }
                            dictionary[card.name].Add(card);
                        }
                        else if (kcDuplicateMergeDict.ContainsKey(card.name) && RunState.DeckList.Any((CardInfo x) => x.name.Equals(kcDuplicateMergeDict[card.name])))
                        {
                            if (!dictionary.ContainsKey(kcDuplicateMergeDict[card.name]))
                            {
                                dictionary.Add(kcDuplicateMergeDict[card.name], new List<CardInfo>());
                            }
                            dictionary[kcDuplicateMergeDict[card.name]].Add(card);
                        }
                    }
                }
                HashSet<Ability> hashSet = new();
                HashSet<Ability> hashSet2 = new();
                foreach (KeyValuePair<string, List<CardInfo>> keyValuePair in dictionary)
                {
                    List<CardInfo> value = keyValuePair.Value;
                    string hostCardName = keyValuePair.Key;
                    value.Sort((CardInfo lhs, CardInfo rhs) => rhs.NumAbilities - lhs.NumAbilities);
                    CardInfo hostCardInfo = value.First((CardInfo x) => x.name.Equals(hostCardName));
                    modifiedList.Add(hostCardInfo);
                    value.RemoveAll((CardInfo x) => x.name.Equals(hostCardName));
                    hashSet.Clear();
                    foreach (Ability item in hostCardInfo.Abilities)
                    {
                        hashSet.Add(item);
                    }
                    int num = -1;
                    CardInfo duplicateCardInfo = null;
                    foreach (CardInfo cardInfo2 in value)
                    {
                        hashSet2.Clear();
                        foreach (Ability item3 in cardInfo2.Abilities)
                        {
                            hashSet2.Add(item3);
                        }
                        hashSet2.UnionWith(hashSet);
                        if (num < hashSet2.Count)
                        {
                            num = hashSet2.Count;
                            duplicateCardInfo = cardInfo2;
                        }
                    }
                    modifiedList.Add(duplicateCardInfo);
                }
                __result.AddRange(modifiedList);
            }
        }

        [HarmonyPatch(typeof(DuplicateMergeSequencer), "OnSlotSelected")]
        [HarmonyPrefix]
        private static bool OnSlotSelectedWithNewMerges(MainInputInteractable slot, DuplicateMergeSequencer __instance)
        {
            if (SaveFile.IsAscension && KCTalkingCards.Plugin.talkingCardsNontalkingMergeFlag)
            {
                __instance.selectionSlot.SetEnabled(false);
                __instance.selectionSlot.ShowState(HighlightedInteractable.State.NonInteractable, false, 0.15f);
                __instance.confirmStone.Exit();
                List<CardInfo> list = __instance.GetValidDuplicateCards();
                /* Remove ordering by name in original method
                 * list = (from c in list
                        orderby c.name
                        select c).ToList<CardInfo>();*/
                (slot as SelectCardFromDeckSlot).SelectFromCards(list, new Action(__instance.OnSelectionEnded), false);
                return false;
            }
            return true;
        }
    }
}