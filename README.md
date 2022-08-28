KCTalkingCards
===============

An Inscryption mod that adds the talking cards from Part 1 into Kaycee's Mod. The Stoat, Stinkbug, and Stunted Wolf will show up in card choices and the mod also adds a starter deck containing the three talking cards.

The talking cards use their base animated portrait. Any dialogue when you draw them to your hand from your deck has been skipped to speed up play. Talking cards are unique and once you have a talking card in your deck, no other copy of that talking card will show up in card choices.

You can fine-tune how you want the talking cards to work in your configuration. Please check the settings out!

## Balancing

The talking cards use their original Part 1 stats by default but you can apply some balancing by setting `TalkingCardsBalance` to `true` in the configuration. You can see the exact changes for the balancing below but the Stoat and Stunted Wolf would be functionally identical to the Stoat and Wolf cards in Kaycee's Mod. As the Stinkbug has no direct counterpart it has been manually balanced to account for its cheap cost and sigil.

If you have the [MycoMerger](https://inscryption.thunderstore.io/package/RykeDaxter/MycoMerger/) mod installed, you can also set `TalkingCardsNontalkingMerge` to `true` to allow the talking cards to be merged with their non-talking counterpart at the Mycologists event. You can change what that counterpart is in the configuration but the recommended default is Talking Stoat with Stoat, Stinkbug with RingWorm, and Stunted Wolf with Wolf. When setting the card name in the configuration, it must be the [internal card name](https://github.com/MADH95/JSONLoader/blob/master/Card%20Names.txt) and not the displayed card name.

The Talking Cards starter deck when balanced is roughly equivalent to the Vanilla starter deck, swapping out the Bullfrog for the Stinkbug. The balancing attempts to bring the cards closer to the base game, giving no advantage for having them other than the cards talking and being animated.

## Configuration

You can adjust the mod's settings using your mod manager's Config editor or by manually editing the `rykedaxter.inscryption.kctalkingcards.cfg` file in `/Bepinex/config`.

## Installation

* You can use the [Thunderstore](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager), [r2modman](https://inscryption.thunderstore.io/package/ebkr/r2modman/), or another compatible mod manager to automatically install this mod from the [Thunderstore page](https://inscryption.thunderstore.io/package/RykeDaxter/KCTalkingCards/). 
* You can manually install this mod by downloading the dll from the [Thunderstore page](https://inscryption.thunderstore.io/package/RykeDaxter/KCTalkingCards/) or the latest [Github release](https://github.com/RykeDaxter/KCTalkingCards) then placing `KCTalkingCards.dll` into `/BepInEx/plugins` assuming you have already installed the required dependencies ([BepInEx-BepInExPack_Inscryption](https://inscryption.thunderstore.io/package/BepInEx/BepInExPack_Inscryption/) and [API_dev-API](https://inscryption.thunderstore.io/package/API_dev/API/)). For intructions on how to install the dependencies, please refer to their respective pages.
* You can optionally install the [MycoMerger](https://inscryption.thunderstore.io/package/RykeDaxter/MycoMerger/) mod to allow talking cards to be merged with their non-talking counterparts.

## Issues and Future Updates

#### Issues

* No known issues but let me know if you find any! 

#### Future Updates

I've added everything I could think of so no further updates are planned. The mod only focuses on including the talking cards from Part 1 into Kaycee's Mod so there's not much more to add. 

If you find an issue or have suggestions, please feel free to contact me on the [Inscryption Modding Discord](https://discord.gg/ZQPvfKEpwM) or create an Issue on the [Github repository](https://github.com/RykeDaxter/KCTalkingCards).

Contributions are welcome!

## Contents

<details>
<summary>3 New Cards:
</summary>

#### Default

|Name|Power|Health|Cost|Sigils|Specials|Traits|Tribes|
|:-|:-|:-|:-|:-|:-|:-|:-|
|Stinkbug|1|2| <img align="center" src="https://i.imgur.com/beJhD7d.png">|Stinky|TalkingCardChooser|DeathcardCreationNonOption|Insect|
|Stoat|1|3| <img align="center" src="https://i.imgur.com/H6vESv7.png">||TalkingCardChooser|DeathcardCreationNonOption||
|Stunted Wolf|2|2| <img align="center" src="https://i.imgur.com/H6vESv7.png">||TalkingCardChooser|DeathcardCreationNonOption|Canine|

#### Balanced

|Name|Power|Health|Cost|Sigils|Specials|Traits|Tribes|
|:-|:-|:-|:-|:-|:-|:-|:-|
|Stinkbug|0|1| <img align="center" src="https://i.imgur.com/beJhD7d.png">|Stinky|TalkingCardChooser|DeathcardCreationNonOption|Insect|
|Stoat|1|2| <img align="center" src="https://i.imgur.com/H6vESv7.png">||TalkingCardChooser|DeathcardCreationNonOption||
|Stunted Wolf|3|2| <img align="center" src="https://i.imgur.com/62GUUAC.png">||TalkingCardChooser|DeathcardCreationNonOption|Canine|
</details>

<details>
<summary>1 New Ascension Starter Decks:
</summary>

|Name|Unlock Level|Cards|
|:-|:-|:-|
|Talking Cards|0| Stoat,  Stinkbug,  Stunted Wolf|
</details>

<details>
<summary>8 New Configs:
</summary>

|Section|Key|Description|
|:-|:-|:-|
|General|NontalkingStoatAppearsInCardChoices|The non-talking stoat card will appear in card choices when true.|
|General|TalkingCardsAppearInCardChoices|Talking Cards will show up in common card choices when true. Talking Cards are unique and if you already have one of a Talking Card in your deck, that Talking Card will not show up in card choices.|
|General|TalkingCardsAreRare|Talking Cards will be set as Rare. They will show up in Rare card choices and qualify as Rare for Rarity trials. You can have both this and TalkingCardsAppearInCardChoices active at the same time.|
|General|TalkingCardsBalance|Applies balancing to the talking cards when true and uses the original Part 1 values for the talking cards otherwise.|
|Mycologists|TalkingCardsNontalkingMerge|Allows talking cards to be merged with their non-talking counterparts at the Mycologists when true. Requires the [MycoMerger](https://inscryption.thunderstore.io/package/RykeDaxter/MycoMerger/) mod.|
|Mycologists|TalkingStinkbugCounterpart|The card name that designates the counterpart of the Talking Stinkbug for merging at the Mycologists. Default is "RingWorm".|
|Mycologists|TalkingStoatCounterpart|The card name that designates the counterpart of the Talking Stoat for merging at the Mycologists. Default is "Stoat".|
|Mycologists|TalkingWolfCounterpart|The card name that designates the counterpart of the Talking Wolf for merging at the Mycologists. Default is "Wolf".|
</details>

## Credits

This mod created by RykeDaxter.

Content tables in Readme created with the use of [Readme Maker](https://inscryption.thunderstore.io/package/JamesGames/ReadmeMaker/).

## Changelog

<details>
<summary>Changelog
</summary>

### 1.0.6
- Added compatibility with the [MycoMerger](https://inscryption.thunderstore.io/package/RykeDaxter/MycoMerger/) mod to prevent conflicts. Now requires MycoMerger for merging talking cards with counterparts.

### 1.0.5
- Included talking cards into card choices and added a setting for it
- Added a setting for toggling the talking cards as rare
- Added a setting for placing the non-talking stoat into card choices
- Added a setting for allowing talking cards to be merged with non-talking counterparts at the Mycologists event
- Added settings to assign the talking card counterpart by their internal card name

### 1.0.4
- Added improved art for the talking cards starter deck, the talking cards pixel portraits, and the mod icon.

### 1.0.3
- Fixed the lag when hovering over a starter deck with talking cards in it for the first time.

### 1.0.2
- Original Part 1 stats for the talking cards has been set as the default.

### 1.0.1 
- Fixed README markdown typo.

### 1.0.0 
- **Release**

</details>