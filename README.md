Json.Net Unity3D Extensions
==================== 

## What Is It?

This repo contains converters which fix serializing Vectors/Quaternions. Unity3D Vectors and Quaternions have properties on them which return the same type. This causes an infinite loop while Json.Net is serializing. To solve it, the converter simply writes the x/y/z/w values directly.

## Do I Need To Do Anything?

Not really. The Newtonsoft.Json.Unity folder contains "ConverterInitializer.cs". This script automatically activates in the Editor when scripts are recompiled, and right before the splash screen in the player. It changes the default Json.Net settings to include the Vector and Quaternion converters. If you need to change the default settings you can include more converters there, or take out that script and initialize it manually.

Import the Unity Package into your project, and voila! Head over to [Releases](https://github.com/DeathTBO/Unity3D-Json.Net/releases) to get a package.