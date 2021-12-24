//Unity FPS demo scripts
These are some of the scripts I used for my first person demo in Unity.
I did not include the whole project files for size considerations, 
but if you use Unity you can load these scripts to play with them. Some 
degree of knowledge on basic Unity is nessesary to utilize these. I also 
did not include the first person controller script as I used a premade
free one from the asset store for early prototyping.

//----------------------Level Change
GoToMainWorld.cs gets put on an object in the first scene
ReturnToStart.cs is the same but put on an object in the second level

Don't forget to add scenes to build order in Unity


//-----------------------Weapon
ProjCollide.cs is attached to a projectile prefab object of your choosing (I used a sphere).
That prefab must then be dragged to the refernce slot for 'Magic Atk' A on the player 
script / player prefab. This script will damage any object with the tag 'EnemyTag' on collision. 
This script is crude and will collide with the player object too if not set up correctly.


//------------------------AI
EnemyAI.cs is attached to an enemy prefab (I used rectangle objects). Enemy objets should 
also be navmesh agent components for this script to work and a navmesh build must be done on the 
world objects in the scene (world objects must have navmesh obstacle components added to them 
and be marked static. 'Static' in 3D design is different than programming, in 3D it saves memory) 
AIs must have the tag 'EnemyTag'.


//------------------------Player 
PlayerScript.cs goes onto the player prefab (I used a freeready made sample one from the unity 
store) and requires two reference fields have objects dragged to them in the inspector window 
within the Player Script section. 'Magic Atk A' which requires the magic projectile object prefab 
dragged to it and 'Gem' which should be an empty game object you drag to be a child of your 
magic staff object and move out from the player body, and the magic staff object (I used a 
rectangle and a sphere) should be a child to the player camera which itself is a child of the 
player object.
