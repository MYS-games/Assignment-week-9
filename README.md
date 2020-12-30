# Assignment-9

* Shir Avraham
* Yuval Zarbiv
* Matti Stern

On this part the section we chose is A.2. from the AI file:
We change the game to be a FPS game, and added a weapon to the player.

We added 4 scripts:
* [Gun](https://github.com/MYS-games/Assignment-week-9/blob/master/Assets/Scripts/4-gun/Gun.cs.meta)
* [GunTarget](https://github.com/MYS-games/Assignment-week-9/blob/master/Assets/Scripts/4-gun/GunTarget.cs)
* [EnemyRange](https://github.com/MYS-games/Assignment-week-9/blob/master/Assets/Scripts/4-gun/EnemyRange.cs)
* [EnemySpawner](https://github.com/MYS-games/Assignment-week-9/blob/master/Assets/Scripts/4-gun/EnemySpawner.cs)

**Gun script -**
The gun script handle the player shoot, using raycast and partical system effects.

**GunTarget script -**
The gun Target script handle the enemy (same for the player / engine) hits and update it's life points.

**EnemyRange script -**
The EnemyRange script checks if the player or the engine is in the enemy chase or shoot range, if the player is closer than the engine the enemy attack the player otherwise - attack the engine.

**EnemySpawner script -**
The Enemy Spawner script handle the Spawn of the enemies on the map, if the enemy number below 5 the spawner spawn new enemy (enemy number = 5).

Play on Itch : https://mattistern.itch.io/enemy-assignment9
