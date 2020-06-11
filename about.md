---
layout: default
---

## Credits

This game was made by the following individuals:

| Photo | Name | Bio |
|:-----:|------|-----|
| <img src="{{ site.url }}/static/images/Denali.jpg" alt="picture of Denali" width="200" height="133">  | Denali | Denali is a current UW Bothell student graduating in 2021 with a major in CSSE and minor in business administration. He is involved with many extracurricular activities outside of his studies including, being a Drum Major and student leader of UW Seattle's Husky Marching Band, professional photographer, car enthusiast, and avid athlete. In his free time, he enjoys playing video games, tinkering with his car, and taking on any kinds of side projects. | 
| <img src="{{ site.url }}/static/images/Jayden.jpg" alt="Jayden" width="200" height="200">  | Jayden | Ji, who goes by Jayden, is a senior graduating from the CSSE program in June 2020. In Fall of 2020, he will be joining the University of Washington's Information School's graduate program for Data Science & Business Intelligence. He enjoys going on hikes throughout WA, weight training, and just talking with friends.  |
| <img src="{{ site.url }}/static/images/20200507_174630.jpg" alt="picture of Kyle" width="200" height="133">  | Kyle   | Kyle is a current UW Bothell senior and is graduating in June 2020 with a bachelor's degree in CSSE. He co-owns a virtual reality software company called Anxious Software Inc, known for products such as Virtual Presenter Pro. Kyle loves to work on many side hobbies such as 3d modelling, artificial intelligence, game modding, and game development. If he isn't tinkering with software, you can most likely find him playing competitive games with friends. |
| <img src="{{ site.url }}/static/images/lizzy.png" alt="drawing of Lizzy" width="100" height="163"> | Lizzy  | Lizzy is a current UW Bothell senior and ~~should~~ will be graduating in June 2020. After graduation, she will be joining Google as a software engineer. Her favorite games are TTRPGs, pinball, and (regrettably) Universal Paperclips. She looks forward to expanding her gaming horizons this summer and playing BeatSaber on the Oculus. |
| <img src="{{ site.url }}/static/images/Victor.jpg" alt="picture of Victor" width="200" height="133"> | Victor | Victor is a current CSSE student at UW Bothell, graduating in 2021. He expects he will be using the unity experience he learned working on this game to make other fun projects. 

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

TODO :bug:
