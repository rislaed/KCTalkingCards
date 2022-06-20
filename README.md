# KCTalkingCards
An Inscryption mod that adds the talking cards from Part 1 into Kaycee's Mod. 

This mod adds a starter deck with the Stoat, Stinkbug, and Stunted Wolf talking cards from Part 1. The cards use the base animated portrait and their dialogue when drawn has been skipped to speed up play.

## Balance

The talking cards have been balanced for Kaycee's Mod but you can use their original Part 1 values by setting `TalkingCardsBalance` to `false` in the configuration. You can see the exact changes below but the Stoat and Stunted Wolf are functionally identical to the Stoat and Wolf cards in Kaycee's Mod except that they're not eligible for combining with their non-talking counterparts at the Mycologists event. As the Stinkbug has no counterpart it has been manually balanced to account for its cheap cost and sigil.

The Talking Cards starter deck is roughly equivalent to the Vanilla starter deck, swapping out the Bullfrog for the Stinkbug. The Talking Cards deck has no advantage other than the cards talking and being animated. You will find no other copy of them during the game. If you are doing challenge runs with this deck, know that sacrifices must be made. Otherwise, enjoy.

## Issues

* Lags the first time you hover over the Talking Cards starter deck every time you open the game. As far as I can tell it's due to the talking cards being loaded when you select the starter deck and the cards try to find a camera that doesn't exist yet for their animations.

## Possible Updates

* Option to allow talking cards to be found during the game even if you didn't select the starter deck.
* Option to add a non-talking stinkbug card and allowing it and the non-talking stoat to be found during the game.
* Option to allow talking cards to be combined with their non-talking counterparts at the Mycologists.
* Art for the mod icon, the starter deck icon, and the pixel portraits for the talking cards.

No promises on any of these though suggestions and contributions are welcome. The mod only focuses on including the talking cards from Part 1 into Kaycee's Mod so there's not much to add.

## Contents

3 New Cards:

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
|rykedaxter.inscryption.kctalkingcards|General|TalkingCardsBalance|Applies balancing to the talking cards when true and uses the original Part 1 values for the talking cards otherwise.|

## Changelog

### 1.0.0 
- **Release**