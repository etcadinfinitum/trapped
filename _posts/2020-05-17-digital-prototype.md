---
layout: post
title: Development Log for Digital Prototype
description: Implementation notes and updates for game progress, coinciding with the Digital Prototype deadline for the game.
---

# Development Log Dated 5-17-2020

## Completed Milestones

1. We have successfully implemented the networked component of the game, 
   and the `node` server we set up is configured to share player map 
   positions and unique IDs for player identification.
2. We have a prototype of a maze map in place.
3. We have implemented several forms of PC traps.

## Current Work

* Victor:
* Jayden: Finished core trap mechanics. Need to polish up the teleportation 
  mechanic to work on teleporting players who step on it "randomly". 
  Currently working on creating a minimap that'll show each player's 
  location on a mini HUD in the corner of the screen (Going to be just dots
  on a blank canvas to begin with) 
* Denali: Finished 2 large map prototypes and the basic camera follow.
  Currently working on more advanced camera follow mechanics to make sure
  that the player does not feel disoriented and cannot see the "void"
  when approaching the edges of the maps. I am also working on making
  additional maps and sprucing up the maps already in the game to "set the
  scene" better.
* Kyle: Finished health bar/player status implementation and currently
  making UI optimized better for multiplayer. I am now converting text 
  into TMP for better aesthetic and currently working on visual 
  implementation for status effects (poisoned, stunned, etc) so the 
  players have better understanding of what is going on in the game. 
* Lizzy: I am working on the system which obscures the map for specific 
  players using either timed intervals or in-game events (like reaching 
  a specific part of the map or stepping on a trap tile); originally, 
  I wanted to have this implemented for the prototype deadline but other 
  tasks for this project and other classes have blocked progress.
  The existing work for this feature is [visible on GitHub](https://github.com/etcadinfinitum/trapped/pull/33) 
  and will affect the PC's camera view like this:
  ![gif of blinder mechanics WIP]({% link /static/images/blinder_mechs.gif %})

## Upcoming Features & Backlogged Items

These are the next big features we are planning on implementing (or 
currently working on):

* We would like to create NPC enemies which affect players on collisions; 
  we are still discussing the best way to do this, but we think that the 
  collision will affect PC health and the enemy proximity will not trigger 
  tracking or following behavior.
* Implement player roles with "vision-levels" for the traps. Eg. Only some
  players can see traps or only some players can see a specific type of trap
  while the others cannot.
* Design at least 2 more maps.
* Implement advanced camera follow so that the player does not see "void"
  when approaching the edges of the maps.
* Implement player-player interaction that such as health gain/loss,
  revival, and giving/removing player status effects.   



TODO: List what features or ideas are on the backlog and/or will be completed next.

## Playtesting Analysis

We have not conducted meaningful playtesting yet, but have been testing 
basic functionality (connection to the node server, spawning and removing 
players who join or leave the game, etc) ad hoc.

We will provide a playtesting analysis writeup after our first round 
of testing this week.

## Blockers

Our group members who are not very adept with `git` have been working to 
adapt to collaboration in a shared repository; resolving merge conflicts 
has been a regular occurance. We are adapting to this challenge admirably, 
but it is still a big gotcha.

Looking ahead, if we decide to go in the direction of multiple instances
of the game running at the same time, modifying server code for this may
be a challenge.

TODO: List what obstacles are blocking development efforts.

## Reflection

The team is working together well at this point; different members are
specializing in different tasks to make things are efficient as possible.
As stated we are fussing with git and merge conflicts between meta files
and scene files which is proving to be a nuisance. However, the game as a
whole is coming together well and we are learning a lot about Unity!

TODO: Reflect on the game's state and the development process. List what is working and what is not working.
