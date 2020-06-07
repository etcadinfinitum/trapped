---
layout: default
---

## Credits

This game was made by the following individuals:

| Photo | Name | Bio |
|-------|------|-----|
| TODO  | Denali | Denali is a current UW Bothell student graduating in 2021 with a major in CSSE and minor in business administration. He is involved with many extracurricular activities outside of his studies including, being a Drum Major and student leader of UW Seattle's Husky Marching Band, professional photographer, car enthusiast, and avid athlete. In his free time, he enjoys playing video games, tinkering with his car, and taking on any kinds of side projects. | 
| TODO  | Jayden | TODO |
| TODO  | Kyle   | TODO |
| <img src="{{ site.url }}/static/images/lizzy.png" alt="drawing of Lizzy" width="100" height="163"> | Lizzy  | Lizzy is a current UW Bothell senior and ~~should~~ will be graduating in June 2020. After graduation, she will be joining Google as a software engineer. Her favorite games are TTRPGs, pinball, and (regrettably) Universal Paperclips. She looks forward to expanding her gaming horizons this summer and playing BeatSaber on the Oculus. |
| TODO  | Victor | TODO |

## References

Our muliplayer functionality was adapted from [this example repository on GitHub](https://github.com/valiafetisov/unity-webgl-multiplayer). We added functionality which correctly removes a player's data from the server's local storage when a player disconnects, as well as transmitting all data that is required to be shared.

Our audio effects came from [this pack of free sounds](https://opengameart.org/content/512-sound-effects-8-bit-style). We also used an audio management technique from [Brackeys on YouTube](https://www.youtube.com/watch?v=6OT43pvUyfY) which allowed us to condense the audio sources into one game object that played the sounds globally, and use calls to that game object when ceritan events occured.

Our camera movements were adapted from [this technique on YouTube](https://www.youtube.com/watch?v=ula1o_ZsMU0) that uses the Mathf.Clamp method to restrict the camera to the bounds of each map.

Pixel Dungeon Sprite Sheet
https://opengameart.org/content/pixel-dungeon-graphics-by-watabou

Used for map tileset


Screen Ripple Effect
https://assetstore.unity.com/packages/vfx/shaders/fullscreen-camera-effects/water-ripple-for-screens-83430

Used for teleport screen effect


Glowy Space - 2D Toon Parallax
https://assetstore.unity.com/packages/3d/environments/glowy-space-2d-toon-parallax-116509

Used for glowing eyes in title screen


Health Bar Images
https://github.com/Brackeys/Health-Bar\

Used for health bar image assets


Pixel Font
https://assetstore.unity.com/packages/2d/fonts/free-pixel-font-thaleah-140059

Used the pixel font for most text in the game

TODO :bug: add asset resource

## Description

TODO :bug:
