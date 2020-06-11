---
layout: post
title: Preparing for Beta Playtesting Release
description: What we accomplished leading up to the Beta Release playtesting session.
---

# Development Log Dated 06-02-2020

## Completed Milestones

* Victor: Implemented multiplayer synchronization for player deaths. 
  * When one client dies, other clients will be updated. 
  * On level change, all clients will be revived and updated. 
  * On all player deaths, the scene will change to the credits. 
* Jayden: Implemented teleportation trap "phase states" where the trap will phase in and out of being solid. 
  * This allows players to collectively take a teleport together or walk past it. Aside from that, 
  * I polished up the dart traps and applied a reskin to them to fit each map's theme. 
  * Lastly, I manually set the teleportation locations for each trap on each map and made sure they had a valid
  * teleportation goal.
* Denali: I am currently still working on map refinement. Last week most of the time I had to
  * continue working on this got diverted to working on the death mechanic for our game. Now
  * that I have completed that mechanic I can resume working on other map refinements that rely
  * on that.
* Kyle: I implemented more UI functionality as well as created two new scenes.
  * Animated the tittle scene.
  * Made credit scene.
  * Added a broadcast function that can be called to alert the client of information such as "seperated from group".
* Lizzy: 
  * Changed blinding / vision restriction behavior so that the player has a sprite mask which changes size when vision is being restricted.
  * Add a distance tracker which calculates the median distance of all players in the game, and deals health damage to players which are too far away from their allies. This mechanic is intended to incentivize players to stick together in the maze and not stray from their party.

## Current Work, Upcoming Features, & Backlogged Items

The features that are still in the works are a map "balance beam", that has been implmenented in a branch but did not make
it into the beta because it was very dependent on the death mechanic. Features that we wish to add are lobbies and multiple
concurrent play sessions with multiple groups of players. However, this may prove to be fruitless in the final build because
of its difficulty with websockets.

## Playtesting Analysis

We look forward to seeing the playtesting results from this week and will provide a detailed writeup of this later.

## Blockers

We are not experiencing significant blockers at this time.

## Reflection

The team now has a relatively good grasp of `git` and how to merge new branches into the master game branch so compared to previous weeks
this has proved to be much less of an issue.


