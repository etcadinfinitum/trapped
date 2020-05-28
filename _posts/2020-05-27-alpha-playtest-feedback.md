---
layout: post
title: Alpha Playtesting Reflection
description: We had lots of constructive feedback on our game in its current state, and discuss the takeaways for the next round of features to implement.
---

# Development Log Dated 05-27-2020

We successfully conducted an initial round of playtesting for our game. 
This post will discuss the observations from our gracious playtesters 
and observations we made while observing them.

## Playtesting Analysis

We conducted three playtest sessions with an average of four people. For the first playtest session everyone joined at the same time; some people joined later than others in the second and third playtest sessions. The aggregate notes of these sessions are listed below.

* Minimap blocks health bar, isn’t locked to a specific position on screen (possibly larger bounds than is needed?)
* People like the blinder mechanic, described it as jarring (perhaps a longer fade would be better, rn fade is only half a second).
* Folks were confused why map element also goes black but characters are still visible. Proceeded to explain separation disadvantages & health depletion as upcoming features
* People get stuck on corners -- decrease collider size of player to help players get around corners. 
* WASD is fine, but Scott had issues with unresponsive keys, which may have been a hardware issue or an issue of too many concurrent key presses.
* More UI text is important - notify when players have been stunned, notify that all players must be on the goal to move to next room. Will need UI text also for when 
* Players who reach goal must wait until all people in game are present in order to teleport - currently it just sends you to the next map without the team
* Lots of exclamation when getting teleported -- this is a good thing :grin:
* Stun trap is a bit too long maybe?
* Cooperation [sic]
* Possibly implement a toggle ("m" key) for minimap
* One tester commented he was having fun just running around the map
* Tester commented that her first instinct when going blind was to just sit around and wait for it to go away
* Possibly make blinding last less but occur more frequently

## Reflection

Our biggest takeaway from this round of playtesting is that cooperative 
game mechanics should be prioritized for the beta testing release. Lizzy's 
action item for the beta testing deadline is to implement the mechanics 
that incentivize players to stick in close proximity to each other and 
navigate the maze together. If players do not stick together, some or 
all of them will begin to lose health, and those players with vision will 
begin to have their vision restricted.

For future playtesting to be successful, we need one of the following to 
be supervised or implemented:

1. Latecomers to a playtesting session should not be able to enter the 
    map, because if players have progressed sufficiently in the map, 
    the median vector will be far enough from the start point that 
    incoming players will impact the health of more of the current 
    players.
2. Separate game sessions, or a server-side lockout, needs to be in 
    place to prevent new people from joining once a game has started.

We also reflected on a few easy fixes we could implement for better UX. 
One of these is using a circle collider for the player to make corner 
navigation easier, and the other is moving the minimap to a different 
part of the camera view so that it isn't blocking the health bar. Both 
of these features are expected to be implemented for the beta release.
