# Pong Demo

Pong is a **2D demo for PC**, developed with **Unity in C#**, based on the classic game. The player faces a computer-controlled opponent, with power-ups that temporarily modify gameplay.

The game ends when either contestant reaches **5 points**.

## Features

- Keyboard-controlled vertical paddle movement.
- Computer-controlled opponent that follows the ball’s position.
- Ball movement handled by Unity’s 2D physics.
- Score updated during gameplay.
- Power-ups spawn at regular intervals in random positions.
- Slow-motion power-up.
- Power-up that generates an additional ball.
- Game-over screen with the option to restart.
- Browser-playable demo.

## Controls

- **W or up arrow**: move the paddle upwards.
- **S or down arrow**: move the paddle downwards.

## Repository structure

```text
PongDemo/
├── Assets/             Scenes, scripts, prefabs and game assets
│   ├── Scenes/         Project scenes
│   └── Scripts/        C# source code
├── Packages/           Unity dependency configuration
├── ProjectSettings/    Project settings
├── docs/               Web demo files
└── README.md
```

## Opening the project

Requires **Unity 2022.3.21f1**.

1. Clone the repository or download and extract the ZIP archive.
2. Add the project to Unity Hub by selecting the folder containing `Assets`, `Packages` and `ProjectSettings`.
3. Open the project with Unity 2022.3.21f1.
4. Wait for the assets to finish importing.
5. Open the scene `Assets/Scenes/SampleScene.unity`.
6. Press **Play** to start the game in the Editor.

## Game logic

The player’s paddle uses vertical keyboard input. The opponent moves towards the ball’s vertical position, staying within the boundaries of the field.

The ball spawns with a random initial direction. When it crosses either side boundary, a point is awarded to the opposing contestant. The main ball is replaced after each point; additional balls are removed when they leave the field.

Power-ups activate when hit by the ball:

- **Slow motion**: reduces the game speed to 50% for 5 real-time seconds.
- **Additional ball**: creates a copy of the ball that activated the power-up.

The game manager controls temporary slow motion, the end of the game and restarting. The score resets when the game is restarted.

## Preview

[Play the demo in your browser](https://fanzio.github.io/PongDemo/)
