---
layout: default
---

## Credits

This game was made by the following individuals:

| Photo | Name | Responsibilities | Bio |
|:-----:|------|-----|-----|
| <img src="{{ site.url }}/static/images/Denali.jpg" alt="picture of Denali" width="200" height="133">  | Denali | Level Design & Maps | Denali is a current UW Bothell student graduating in 2021 with a major in CSSE and minor in business administration. He is involved with many extracurricular activities outside of his studies including, being a Drum Major and student leader of UW Seattle's Husky Marching Band, professional photographer, car enthusiast, and avid athlete. In his free time, he enjoys playing video games, tinkering with his car, and taking on any kinds of side projects. | 
| <img src="{{ site.url }}/static/images/Jayden.jpg" alt="Jayden" width="200" height="200">  | Jayden | Trap Design & Functionality | Ji, who goes by Jayden, is a senior graduating from the CSSE program in June 2020. In Fall of 2020, he will be joining the University of Washington's Information School's graduate program for Data Science & Business Intelligence. He enjoys going on hikes throughout WA, weight training, and just talking with friends.  |
| <img src="{{ site.url }}/static/images/kyle.jpg" alt="picture of Kyle" width="150" height="227">  | Kyle | Visuals, UI, and Character Creation  | Kyle is a current UW Bothell senior and is graduating in June 2020 with a bachelor's degree in CSSE. He co-owns a virtual reality software company called Anxious Software Inc, known for products such as Virtual Presenter Pro. Kyle loves to work on many side hobbies such as 3d modelling, artificial intelligence, game modding, and game development. If he isn't tinkering with software, you can most likely find him playing competitive games with friends. |
| <img src="{{ site.url }}/static/images/lizzy.png" alt="drawing of Lizzy" width="100" height="163"> | Lizzy | Networking, Vision Mechanics, & Website | Lizzy is a current UW Bothell senior and ~~should~~ will be graduating in June 2020. After graduation, she will be joining Google as a software engineer. Her favorite games are TTRPGs, pinball, and (regrettably) Universal Paperclips. She looks forward to expanding her gaming horizons this summer and playing BeatSaber on the Oculus. |
| <img src="{{ site.url }}/static/images/Victor.jpg" alt="picture of Victor" width="150" height="200"> | Victor | Networking & Enemy AI | Victor is a current CSSE student at UW Bothell, graduating in 2021. He expects he will be using the unity experience he learned working on this game to make other fun projects. 

## References

### Networking

Our muliplayer functionality was adapted from [this example repository on GitHub](https://github.com/valiafetisov/unity-webgl-multiplayer). We added functionality which correctly removes a player's data from the server's local storage when a player disconnects, as well as transmitting all data that is required to be shared.

### Sprite Assets & Art

This [Pixel Dungeon Sprite Sheet](https://opengameart.org/content/pixel-dungeon-graphics-by-watabou) was used for our dungeon map tilesets.

[Glowy Space - 2D Toon Parallax](https://assetstore.unity.com/packages/3d/environments/glowy-space-2d-toon-parallax-116509) was used for the glowing eyes in the title screen.

We used health bar images from [GitHub](https://github.com/Brackeys/Health-Bar/).

For text, we used this [Pixel Font](https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059) from the Unity store. It was used as the font for most text in the game.

### Visual Effects

Our camera movements were adapted from [this technique on YouTube](https://www.youtube.com/watch?v=ula1o_ZsMU0) that uses the Mathf.Clamp method to restrict the camera to the bounds of each map.

This [screen ripple effect](https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/water-ripple-for-screens-83430) was used for the ripple effect in the client when being teleported.

### Audio Assets

Our audio effects came from [this pack of free sounds](https://opengameart.org/content/512-sound-effects-8-bit-style). We also used an audio management technique from [Brackeys on YouTube](https://www.youtube.com/watch?v=6OT43pvUyfY) which allowed us to condense the audio sources into one game object that played the sounds globally, and use calls to that game object when ceritan events occured.

## Description

Because of the current socially distanced situation, we wanted to create a cooperative online game friends can all enjoy together. Trapped is a multiplayer cooperative game made for WebGL where you and up to three other friends work together to navigate a maze by avoiding ghosts, traps, and other obstacles. We took inspiration from the classic Pacman, as well as dungeon crawling adventure games in terms of the look, feel, and sound effects. 

We set out to create some specific guidelines about the game. Things such as relying on your teammates for visual guidance, trap avoidance, and navigation. These emphasize the cooperative and co-dependent nature of the game. Even when a player has “died”, they’re not completely out of the game and can help aid their teammates by being human shields for traps or as a navigation aide. This way, no one is essentially left out for dying early and can still contribute toward winning.  

Mechanics include:
- Group distance calculation, which prevents players from straying too far from the group. 
- Vision limiting mechanic which restricts vision of the maze and blinds players on taking damage from certain obstacles.
- UI popup messages that inform players to certain triggers such as traps.
- Websocket multiplayer framework that synchronizes player movement, player deaths, and teleportation to next maze on level completion.

Obstacles include:
- A navmesh ghost which calculates in real time an optimal path to the players, forcing players to run or take damage. 
- Three unique traps players must avoid. 
- Balance beam sections where players must avoid falling into the pit.

Once a player dies it does not mean game over; that player becomes a zombie that moves slow and burdens the rest of the team.

### Rating

The game is appropriate for children and should be considered by ESRB as E for Everyone.

### Launch Date

The launch date for Trapped is June 12th 2020 at midnight on WebGL, accessible to all internet browsers. 

The server is currently hosted on DigitalOcean, and while the hosting is not expected to change, long-term support will likely not be available and manual restart of the server is required when an exception occurs.

Anyone may download a copy of the game, configure, and host their own server from this [repo](https://github.com/etcadinfinitum/trapped).
