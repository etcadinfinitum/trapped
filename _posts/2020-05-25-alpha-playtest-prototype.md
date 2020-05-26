---
layout: post
title: Alpha Playtesting Readiness & Progress
description: Here's what we accomplished leading up to the deployment of a prototype that is ready for alpha playtesting.
---

# Development Log Dated 05-25-2020

## Completed Milestones

* Lizzy: [Generated SSL/TLS certificates for the host of our multiplayer server.]({% link _posts/2020-05-19-networking-devlog.md %})
* Lizzy: Implemented vision obscuration for players.
    * This game mechanic makes the maps more difficult (and more interesting).
    * This feature is a core tenet of our original idea, and will hopefully foster interdependence between the players as they help each other navigate and avoid obstacles.
    * We may utilize this feature in future map development and additional traps.
* Denali: Implmemented camera to not exceed world bounds, and work for all players. Used clamp functions rather than hardcoding all          * bounds.
* Denali: Put trap strategicly around maps. Further progressed level design.
* Victor: Reworked multiplayer2d script to deserialize different messages from the server, as well as server logic for assigning player join order. 
	* Each client can access otherPlayer prefabs by join order assigned to them.
	* A client that terminates its connection to server is disconnected properly and destroyed on other client's game.
* Victor: Implemented a goal mechanic that teleports all players to the next location when all players are standing on it. 
* Victor: Implemented an enemey behavior that chases the first player to connect using a NavMeshPlus dependency for 2D. 
* Victor: Refactored the main scene to use prefabs to decrease future headache merge conflicts.
* Jayden: Created pressure plate mechanic. Trigger is attached to a separate shooting object. 
* Jayden: Implemented a minimap for each player. Still testing largeness of minimap vs. usability 
* Jayden: Made dart-behavior to interact with player behavior 

## Current Work

* Victor:
	* Need to finish up enemy hurt mechanics so that they deal damage to the player. Will start working on death mechanics after that.  
* Jayden: 
    * Working on refactoring current traps. 
    * Redesigning arrow mechanic - Each player has small arrows surrounding themself that point in the direction of other players. 
* Denali: Making new maps that support NPC movement. We found that NPCs cannot track playerse on a navmesh through single-tile
   * corridors, so we are keeping the old ones, but designing additional maps with two-tile wide corridors so that the NPCs
   * can effectively track the players and chase them within the map. After this, will be working on implmeneting new traps
   * from Jayden into the new maps as well as helping the multiplayer design.
* Kyle:
* Lizzy: Health depletion mechanics for players which become too far separated from each other; completion planned for 5/31.

## Upcoming Features & Backlogged Items
* Collision layering and matrix modification for collisions between traps, enemies, and the players. 
* Arrow guides that point to other players in the maze.
* New maze that allows for navmesh pathing (2 wide corridors vs current 1 wide)
* Enemy hurt mechanics.
* Death mechanics.
* Tittle screen and credit screen.
* Communication from server to players on who currently has vision and who is currently blind.

##### Networking

Our project still needs to address coordination of a single game, and prevent latecomers from joining, or some other gatekeeping mechanism that will let players assemble before being placed on the map. It would be nice to allow multiple game sessions at the same time (the way [Jackbox Party Pack does](https://www.jackboxgames.com/how-to-play/)).

##### Player Interdependency

We are getting to a point in development that we are ready to focus on how our game's design can foster player interactions and cooperation. We are looking at healthmechanics, and will be creating additional maps that have features which should be cooperatively tackled. 

##### Player Health

We have map elements and game mechanics in the pipeline that affect the player's health, and will be focusing on releasing those features in the next few days.

## Playtesting Analysis

We are excited to get some playtesters for our game in its current form, and hopefully get some actionable input about what features they like or do not like.

## Blockers

For some of us. GIT is still proving to be an issue, especially when trying to merge .unity scene files. We've just recently learned a technique for decreasing
scene conflicts (using prefabs), and hopefully these headache merges will be minimized going forward. 

## Reflection

TODO: Reflect on the game's state and the development process. List what is working and what is not working.
The game is together in our master branch, as stated before, multiplayer still needs some work. However, maps and many player-oriented
features are coming together well and looking great. 