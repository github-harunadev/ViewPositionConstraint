# ViewPositionConstraint
Very simple Unity C# script that automatically syncs avatar's view position with avatar Head bone scale.

## YouTube Video
[![How to use View Position Constraint YouTube video](https://img.youtube.com/vi/NkRkjRGp6bM/0.jpg)](https://www.youtube.com/watch?v=NkRkjRGp6bM)

## What does it do?
Once the constraint is activated, it will try to sync your avatar's view position property with your avatar's head bone.

## How to use?
1. Import .unitypackage to your project.
### Using it on your avatar's head bone
3. Find your avatar's Head bone.
4. Add View Position Constraint via "Add Component" button.
5. Make sure your current view position is well-aligned with your needs.
6. Press Activate to let it automatically configure the current offset & activate.
7. You're now free to scale up/down the head bone. You can even scale up/down parent bones such as neck, chest, hips, or more.
### Using it on separate GameObject inside head bone
3. Find your desired GameObject.
4. Add View Position Constraint via "Add Component" button.
5. Make sure your current view position is well-aligned with your needs.
6. Press Zero to simply activate it without calculating offset.
7. You're now free adjust the object's position.

## Requirements
- Unity 2022 3.22f1
- VRChat Avatar SDK (Use VRChat Creator Companion)

## Download
[Download latest .unitypackage file from here](https://github.com/github-harunadev/ViewPositionConstraint/releases)
