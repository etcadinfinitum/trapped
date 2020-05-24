---
layout: post
title: Pathfinding and 2D Navmesh Challenges
description: We had to change our map philosophy to allow pathfinding for enemy NPCs; here's a short note about the work Victor did to get this figured out.
---

# Development Log Dated 05-23-2020

## Completed Milestones

- Made an enemy navmesh agent that chases players around in the maze. (Victor)

## The Problem

Our original thinking for an enemy chasing a player through a maze was that it would be simple. Just use a navmesh and 
navmesh agent, badabingbadaboom, task done in a couple of minutes. However, like most tasks in unity, it's not that simple.

Turns out, navmesh agents aren't supported for 2D. After some minutes googling, it appears that there are a couple of 
solutions available to me.

1. Make the project 3D and pretend it's 2D, putting sprites on 3D objects. 
Ok, cool, maybe next project, but we have done too much work in 2D at this point to convert everything.

2. Import third party navmesh components for 2D.
Open source is the best. Turns out other people have already solved this problem for me. There are a couple components out there,
one we found [in this thread](https://answers.unity.com/questions/1492606/unity-2d-navmesh-for-a-tilemap.html)
and the we decided to go with: https://github.com/h8man/NavMeshPlus

NavMeshPlus by h8man is really well documented, and is ready to go by simply adding this dependency: 
```
"com.h8man.2d.navmeshplus": "https://github.com/h8man/NavMeshPlus.git#master"
```


## The Next Problem
Good news: We've gotten the pathing to work so that the enemy will chase players.
Bad news: doesn't work with our current mazes.

Our current maze is too narrow, paths don't form in a 1 long corridor.
Paths must be at least 2 units wide due to how paths are carved out from the obstacles.

## Current Work & Other Information

Pathfinding and navmesh agents are working, but now we are faced wit the task of recreating the maze, or studying the navmesh code
to see if we can change the way paths are carved around obstacles.

## Reflection

Going forward, we will make sure to plan out pathfinding before we make the maps and mazes. 
