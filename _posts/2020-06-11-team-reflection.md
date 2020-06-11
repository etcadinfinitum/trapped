---
layout: post
title: Team Reflection
description: A post-mortem of this project is in order; here, we describe what we are proud of, what we wanted to accomplish but did not have time to implement, and what we could improve on for next time.
---

# Team Reflection

## Specific Questions

> What is the one thing your team did really well? What evidence can you show for it? 

The majority of the groups decided to choose the “exponential” theme for their game but, because of this, our group decided to try our hands at the “networked multiplayer” theme to stand out. Especially in the context of being virtual and socially distant, we wanted to create a game someone could play with their friends. Despite the challenges with reinventing the wheel for this project in terms of networking, our group feels we’ve excelled in this aspect. With our own internal playtesting as well as the public play tests we’ve done with the rest of our CSS 385 classmates, we’ve gotten ample feedback that the game runs in real-time and holds a reliable connection during play-time. 

> If you had another 2 weeks to work on the game, what would be the 3 highest priority items?

With the time constraints of the quarter, we’ve had to reduce the scope of our project and were unable to implement some of our most ambitious features. Our current built game only supports one player session with 4 players maximum so we would’ve liked to implement multi-multiplayer session hosting, allowing many different groups to play at once. Another feature we’ve wanted to have were “roles” for each player so it enforces the co-dependency play even more; where a player would have special abilities or a deficiency that’d help or hinder the team. Lastly, we wanted to have a multiplayer chat or voice call because of the cooperation aspect of the game. These were all very ambitious features that unfortunately had to be cut due to time constraints. 

## General Comments

### Development Process

As a team, we did a good job of identifying individual tasks in our project that had no interdependencies; this was a core compoenent of our approach to implementing the game and started in the first week of development work. The task itemization and delegation is reflected in our GitHub repository's [issue board](https://github.com/etcadinfinitum/trapped/issues), which was our primary way of formally tracking work in progress and task completion.

Additionally, each of us did an outstanding job functioning as self-directed project managers. We all self-delegated features extremely well from the beginning, and no one person in the group needed to step in to ask other group members to contribute to the project. As a group, that initiative and sense of responsibility reflects our respect for our group members as well as our enthusiasm for the project we were working on.

We feel that the only aspect of our project which didn't always get enough attention is documentation in general; detailed development log entries were not an organic part of our release cycles and we had to remind ourselves to document our work at several stages.

### Technical Details

Overall, we think we executed a lot of generic ideas well, but some of the details of what we wanted to achieve were overlooked. For example, we were able to send important information about each player (e.g. position on map) in the game to all clients using our networked client-server functionality, but we did not implement a small feature which shares and displays the names of every player on all clients. In hindsight, this would be relatively simple to accomplish, but we focused on larger, more significant game mechanics. Overall, we are proud of the well-roundedness of our game's concept, but polishing specific details were sometimes overlooked, and the saying "the devil is in the details" applies here.

For the game's implementation, we also suffered from [feature creep](https://en.wikipedia.org/wiki/Feature_creep). Initially, we had a relatively straightforward concept in mind for our game, but playtesting feedback revealed that we needed to add functionality which supported game mechanics that we wanted. A prime example of this was UI notifications for specific in-game events; we had supposed that game events like damage and teleporting would be obvious to the player but playtesting revealed that this was not, and so we decided to provide on-screen text to notify the player what happened when specific events occurred. Fortunately, this particular example worked in our favor, because the framework we built for displaying UI notifications could be used in all sorts of circumstances that were significant for game progress.

