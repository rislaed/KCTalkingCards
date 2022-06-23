KCTalkingCards
===============

An Inscryption mod that adds the talking cards from Part 1 into Kaycee's Mod. 

This mod adds a starter deck with the Stoat, Stinkbug, and Stunted Wolf talking cards from Part 1. The talking cards use the base animated portrait. Any dialogue when you draw them to your hand has been skipped to speed up play.

## Balancing

The talking cards use their original Part 1 stats by default but you can apply some balancing by setting `TalkingCardsBalance` to `true` in the configuration. You can see the exact changes for the balancing below but the Stoat and Stunted Wolf would be functionally identical to the Stoat and Wolf cards in Kaycee's Mod except they're not eligible for combining with their non-talking counterparts at the Mycologists event. As the Stinkbug has no counterpart it has been manually balanced to account for its cheap cost and sigil.

The Talking Cards starter deck when balanced is roughly equivalent to the Vanilla starter deck, swapping out the Bullfrog for the Stinkbug. The Talking Cards deck when balanced has no advantage other than the cards talking and being animated. You will find no other copy of the talking cards during the game. If you are doing challenge runs with the balanced Talking Cards starter deck, know that sacrifices must be made. Otherwise, enjoy.

## Installation

* You can use the [Thunderstore](https://www.overwolf.com/app/Thunderstore-Thunderstore_Mod_Manager), [r2modman](https://inscryption.thunderstore.io/package/ebkr/r2modman/), or another compatible mod manager to automatically install this mod from the [Thunderstore page](https://inscryption.thunderstore.io/package/RykeDaxter/KCTalkingCards/). 
* You can manually install this mod by downloading the dll from the [Thunderstore page](https://inscryption.thunderstore.io/package/RykeDaxter/KCTalkingCards/) or the latest [Github release](https://github.com/RykeDaxter/KCTalkingCards) then placing `KCTalkingCards.dll` into `/BepInEx/plugins` assuming you have already installed the required dependencies ([BepInEx-BepInExPack_Inscryption](https://inscryption.thunderstore.io/package/BepInEx/BepInExPack_Inscryption/), [BepInEx-MonoMod_Loader_Inscryption](https://inscryption.thunderstore.io/package/BepInEx/MonoMod_Loader_Inscryption/), and [API_dev-API](https://inscryption.thunderstore.io/package/API_dev/API/)). For intructions on how to install the dependencies, please refer to their respective pages.

## Issues

* Let me know if you find any!

## Possible Updates

* Option to allow talking cards to be found during the game even if you didn't select the starter deck.
* Option to add a non-talking stinkbug card and allowing it and the non-talking stoat to be found during the game.
* Option to allow talking cards to be combined with their non-talking counterparts at the Mycologists.
* Adding KC-compatible versions of Fishbot and Lonely Wizbot (Angler and Lonely Wizard)

No promises on any of these though suggestions and contributions are welcome. The mod only focuses on including the talking cards from Part 1 into Kaycee's Mod so there's not much more to add.

## Contents

3 New Cards:

Default
|Name|Power|Health|Cost|Evolution|Frozen Away|Tail|Sigils|Specials|Traits|Tribes|
|:-|:-|:-|:-|:-|:-|:-|:-|:-|:-|:-|
|Stinkbug|1|2| <img align="center" src="https://i.imgur.com/beJhD7d.png">|||| Stinky| TalkingCardChooser|DeathcardCreationNonOption|Insect|
|Stoat|1|3| <img align="center" src="https://i.imgur.com/H6vESv7.png">||||| TalkingCardChooser|DeathcardCreationNonOption||
|Stunted Wolf|2|2| <img align="center" src="https://i.imgur.com/H6vESv7.png">||||| TalkingCardChooser|DeathcardCreationNonOption|Canine|

Balanced
|Name|Power|Health|Cost|Evolution|Frozen Away|Tail|Sigils|Specials|Traits|Tribes|
|:-|:-|:-|:-|:-|:-|:-|:-|:-|:-|:-|
|Stinkbug|0|1| <img align="center" src="https://i.imgur.com/beJhD7d.png">|||| Stinky| TalkingCardChooser|DeathcardCreationNonOption|Insect|
|Stoat|1|2| <img align="center" src="https://i.imgur.com/H6vESv7.png">||||| TalkingCardChooser|DeathcardCreationNonOption||
|Stunted Wolf|3|2| <img align="center" src="https://i.imgur.com/62GUUAC.png">||||| TalkingCardChooser|DeathcardCreationNonOption|Canine|

1 New Ascension Starter Decks:

|Name|Unlock Level|Cards|
|:-|:-|:-|
|Talking Cards|0| Stoat,  Stinkbug,  Stunted Wolf|

1 New Configs:

|GUID|Section|Key|Description|
|:-|:-|:-|:-|
|rykedaxter.inscryption.kctalkingcards|General|TalkingCardsBalance|Applies balancing to the talking cards when true and uses the original Part 1 stats for the talking cards otherwise.|

## Changelog

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
