---
layout: post
title: Beta Release Playtesting Retrospective
description: Playtesting our latest version of our project uncovered a number of problems; we also brainstormed solutions to fix most, if not all, of these issues.
---

# Development Log Dated 06-03-2020

## Playtesting Analysis

After taking notes about things as they occurred, a few themes for comments 
and observations became apparent. They are listed here by general 
category/gameplay behavior.

### Game Connectivity

* We desperately need to lock players out of a current game, especially 
  now that a calculated distance vector causes damage to all players
  * Potential fix: require password to connect, give password to only 
    the intended people
  * Potential fix: secondary connection screen (like a Jackbox game) 
    where players verbally give each other a join code. Two buttons 
    on connect screen - create new session, or join existing session
    * Nice to have: icons for each player who joined, along with their name
    * Need: one "Start Game" button for the person who created the game session
* Change IP to be optional field (make that clearer in connection screen)
* General aesthetics could use some work
* Ghosts aren’t synced

### In-game Notifications

* More messages on screen / instructions for the player -- "I wouldn't 
  have known what was going on if you hadn’t told me"
* Text isn’t being sent to other players
* Need some sort of tutorial/instruction screen telling what’s going on

### Death Mechanics

* "It’s too easy to die"
  * For teleportation, can we limit it to a range from the character's 
    current position? Some of the teleportation traps sent me into a 
    different map altogether
  * Teleportation of zombie person causes damage to other folks who 
    are still alive?
* Also ghosts chase zombie players still
* Ghost is too fast and kills players too fast
* Teleporting will land you in walls sometimes -- it happened to me 
  several times and I saw it happen to others several times

### Game Progression

* Goal did not teleport players -- need to fix teleportation + add locations 

### Vision Restrictions

* Vision restriction choices seem random (because they are) -- tie this 
  into a game mechanic better 
  * Fix: When you hit a trap, when you take damage, etc you are blinded 
    for 5s, and your upper vision limit is restricted slightly
  * Fix: When you stray from the group, your vision decreases temporarily

### General Comments

* ~~2~~ 3 people said it was fun
* I (Lizzy) made it through the map unscathed a total of 1x after playing 
  like 4-5 games. It might have gone better if people weren’t joining mid session
* 1 person (Kieran) said it was impressive that the networking component 
  works as well as it does

## Reflection

In this playtest session, it became apparent that our game is not very 
polished, and there are a number of mechanics that work okay separately 
but don't tie together very well. 

Our focus for the final release will be to polish the existing functionality 
that we have and make the game playable in a meaningful way which doesn't 
require a developer to babysit and explain what is happening on the screen. 
