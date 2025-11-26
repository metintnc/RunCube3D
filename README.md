# RunCube3D - MyFirstGame 🏃‍♂️

A physics-based 3D endless runner developed using the **Unity** game engine and **C#**, featuring dynamic camera angles. It offers reflex-oriented gameplay similar to *Geometry Dash*.

## 🎮 Gameplay & Features

Beyond a basic runner game, this project was built to test and develop specific game mechanics:

* **Physics-Based Movement:** Fluid movement mechanics developed using `Rigidbody`.
* **Dynamic Camera System:** A smart camera tracking system that changes its angle and height based on the player's position (Z-axis), offering cinematic transitions (`CameraFollow.cs`).
* **Ragdoll Death Effect:** Instead of a standard "Game Over" screen, upon hitting a trap, the character shatters into pieces with a physics-based explosion force applied (`Control.cs`).
* **Persistent Death Counter:** A system using `DontDestroyOnLoad` and the **Singleton Design Pattern** to carry data across scenes and track the player's total death count (`olumsayac.cs`).
* **Regional Difficulty:** Jump force and camera angle change dynamically via code in specific map regions (based on Z coordinates).

## 🕹️ Controls

* **Movement (Left/Right):** `A` / `D` or `Left Arrow` / `Right Arrow`
* **Jump:** `Space`

## 🛠️ Technical Details and Code Structure

The project is designed with a modular structure following **Object-Oriented Programming (OOP)** principles.

### 1. Character Controller (`Control.cs`)
* Manages player movement via the physics engine (`linearVelocity`).
* Uses an advanced **Ground Check** mechanism utilizing `Physics.CheckSphere`.
* Upon colliding with traps (`Trap` tag), it destroys the character, instantiates a Ragdoll prefab, and applies an explosion effect using `AddExplosionForce`.

### 2. Camera Follow (`CameraFollow.cs`)
* Follows the player smoothly using `Vector3.Lerp` and `Quaternion.Lerp`.
* **Hardcoded Level Design:** Dynamically changes the camera's Height (Y) and follow distance using `if-else` blocks based on the player's Z position to alter the game atmosphere.

### 3. Game Loop and Singleton (`olumsayac.cs` & `RestartGame.cs`)
* **Singleton Pattern:** Ensures the death counter is managed via a single instance so it doesn't reset in every scene.
* **Scene Management:** Provides a fast game loop (retry mechanic) by reloading the scene directly upon restart.

---

## 📸 Screenshots
<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/db0c6baf-3bbf-4227-88a0-c19180798345" />

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/78d4da53-e7ad-4f7f-957c-66a7e9fc008f" />

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/1b57a43e-6f6a-4405-b4a0-0e6fef2d6fbd" />

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/399d0fd3-2abe-4d7f-a0a2-341f83e37179" />

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/b54423c8-4475-4187-9fb6-cb39f6c5e8c5" />

<img width="1919" height="1079" alt="image" src="https://github.com/user-attachments/assets/37dcbba6-306e-44f2-87d0-b2ab805b14c5" />
