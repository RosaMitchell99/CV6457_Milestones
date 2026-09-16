# Milestone 0 

Name: Siqi Han
Email: shan602@gatech.edu
Canvas account name: Siqi Han
Main Scene: Minigame (as indicated in the tutorial)
Unity Version: 6000.0.82f1 (LTS)
Development System: Windows

## Overall Introduction

This is a modified version of the Unity Roll-a-Ball tutorial.(https://learn.unity.com/course/roll-a-ball?version=6.0)

The main modifications include:

· Player respawning when the ball falls out
· Three special items with temporary effects and visual feedback
· New skybox, lighting, and environmental decorations
· Modified materials and shapes for game objects

## Controls

Use WASD to move the ball.

## Script Modifications

1. Player respawn when falling out of arena
   
   ·Behavior: When the ball falls outside of the arena(out of the walls), it automatically respawns above the center of the ground.

   ·Implementation(PlayerController.cs 62-65): The update function continuously checks the y position of player. If y < -5, it puts the player back to originalPos, which is above the ground at the center of the arena. The rigidbody's linear velocity is also set to zero to reset velocity when respawning.

   ·How to Observe: Roll the ball out of the walls, and let the ball fall down. The ball will automatically reappear above the center and drop to the ground.

2. Three special items and effects
   
   Three special items are added, and the player can try to collect them for special abilities. They are detected through OnTriggerEnter(), activated as coroutines.

   2.1 SizeUp

      ·Behavior: When the player collects the red mushroom, the ball becomes 1.5x its original size for 10 seconds.

      ·Implementation(PlayerController.cs:128-133): The player's scale is multiplied by 1.5. The coroutine waits for 10 seconds, after which the original scale is restored. The mushroom uses a collider box as a trigger.

      ·Observation: Roll the ball into the mushroom, and the ball becomes 1.5x large for 10 seconds.

   2.2 SpeedUp

      ·Behavior: When the player collects the magic ball with wings, the ball's speed becomes 2x of its original speed for 10 seconds.

      ·Implementation(PlayerController.cs:135-140; Floater.cs): The player's speed is multiplied by 2. After waiting for 10 seconds, the original speed is restored. The SpeedUp item also uses the floater script to creating a floating animation. It is implemented by continuously modifying the y position as a time-dependent sine function.

      ·Observation: Roll the ball into the magic ball, and observe that the player moves approximately twice as fast. The increased speed lasts for 10 seconds.

   2.3 Shield

      ·Behavior: When the player collects the capsule on the slope, it becomes invincible (cannot be killed by enemy) and can penetrate through obstacles for 10s. The invincible status is indicated by a black appearance. The shield capsule has both floating and rotating visual effects.

      ·Implementation(PlayerController.cs:142-151;Floater.cs;FasterRotator.cs): To disable player-obstacle collision during invincible periods(for both enemy and obstacles), the project uses "playerLayer" and "obstacleLayer". During the 10 seconds, player-obstacle collision is ignored, allowing the player to pass through obstacles and ignore enemy, while still able to collect pickups and other items. The player's material color is set to black to indicate this status. It also havs floater and rotator(set faster than pickup rotator to make them visually distinct) components for visual effects.

      ·Observation: Roll the ball into the shield capsule on the slope, and the ball changes color to black. During the next 10 seconds, you can roll through the obstacles, contact the enemy, and collect other items. The player should remain active and be able to pass through obstacles.

3. Modified object destruction to avoid errors
   
Originally in the tutorial, in PlayerController.cs line 110 and line 121, the scripts simply destroys certain game objects. During testing, this could result in errors(accessing objects that had been destroyed). I changed this behavior to deactivate relevant objects instead of immediately destroying them.

## 3D Graphics Modifications

1. Custom 3D shapes for special items

I constructed custom 3D shapes for the three special items using spheres, cylinders, and other primitive shapes. I modified their scale, rotation, and positioning to create visual designs. I also created and assigned custom materials with different colors.

The items can be clearly observed in the gameplay.

2. Visual feedback for special item effects

The player's appearance changes when certain items are collected: The ball becomes visibly larger when it touches the mushroom, and it becomes black when it touches the shield capsule.
Collect the items and the visual changes will indicate that a temporary effect is active.

3. Skybox and lighting

I added an external fantasy-style skybox to make the environment more visually immersive. 
Asset used: Fantasy Skybox FREE (link:https://assetstore.unity.com/packages/2d/textures-materials/sky/fantasy-skybox-free-18353). 
I configured the skybox through Window->Rendering->Lighting. 
The new skybox and lighting setup gives the scene a more stylized atmosphere with a sunset setting.

4. Game scene decorations

I imported and added external assets to the ground.
Asset used: Low Poly Trees and Vegetation - Pack (link:https://assetstore.unity.com/packages/3d/environments/low-poly-trees-and-vegetation-pack-265300)
I used trees to decorate the scene. They are distributed around the ground and can be easily observed.

5. Modified materials from original tutorial

I changed some of the default settings of materials and shapes of objects from the original tutorial. These changes were made to better match
the visual design of the game. They can be directly observed during gameplay.

## Modified Scripts

- PlayerController.cs
- Floater.cs
- FasterRotator.cs

## External assets sources

- Fantasy Skybox FREE
- Low Poly Trees and Vegetation - Pack
Only selected assets are used in this project.

## Note

This is a game prototype with relatively rough design.
For further development, transition between the invincible state and the normal state could be improved to make the gameplay smoother.
Please contact me if there is anything wrong with the format or files.

