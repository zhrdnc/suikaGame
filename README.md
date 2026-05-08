# Fruit Pop 🍓
A 2D physics-based mobile puzzle game developed with Unity. The game features a "merge" mechanic where players combine identical fruits to create larger ones and earn points, similar to the popular Suika Game.
<br>
<br>
<br>
## **🚀 Features**<br><br>
Physics-Based Gameplay: Precise 2D collision and gravity mechanics for fruit movement and merging.

Spam Protection: Integrated cooldown system to prevent rapid-fire dropping and ensure a balanced game pace.

Dynamic UI: Responsive Score and Game Over systems designed for mobile aspect ratios.

Seamless Audio: Persistent background music management across scenes using the Singleton pattern.

Atmospheric Design: Hand-drawn digital illustrations integrated into the Unity environment.
<br>
<br>
<br>

## 🛠️ Technical Stack
Engine: Unity 2022.3+

Language: C#

Graphics: Digital Illustration (Krita/Figma)

Platform: Android, PC

<br>
<br>
<br>

## 📁 Key Scripts
fruitcon.cs: Manages fruit physics, horizontal movement via touch/mouse, and the merge logic.

FruitSpawner.cs: Handles the randomized generation of fruits with a specialized check to prevent overlaps.

MusicManager.cs: A persistent audio controller that handles music transitions between the Main Menu and Game Scene.

GameOverDetector.cs: Monitors the "danger zone" at the top of the box and triggers the end-game state with a countdown.

<br>
<br>
<br>

## 🎮 How to Play
Move: Slide your finger (or mouse) to position the fruit.

Drop: Release to let the fruit fall into the box.

Merge: Align two identical fruits to evolve them into a higher-level fruit.

Score: Keep merging to increase your score, but don't let the fruits stay in the danger zone for too long!

<br>
<br>
<br>

## 📸 Screenshots
[Main Menu] <img width="945" height="2048" alt="WhatsApp Image 2026-05-08 at 21 17 26" src="https://github.com/user-attachments/assets/d51ef4ec-cbc8-46d0-985b-4a6d07f01e5c" />
<img width="300" height="700" alt="WhatsApp Image 2026-05-08 at 21 17 27r" src="https://github.com/user-attachments/assets/a0c1778e-d908-4e73-8f8e-3d182fe08676" />
<br>

![Gameplay] <img width="300" height="700" alt="WhatsApp Image 2026-05-08 at 21 17 27" src="https://github.com/user-attachments/assets/6544c78d-017b-42d0-a166-b61227ab8aba" />
<br>
<br>
<br>

## 👩‍💻 About the Developer
I am Zehra, a 2nd-year Software Engineering student. As an aspiring Technical Artist, I focus on the intersection of clean, efficient code and creative digital design.

