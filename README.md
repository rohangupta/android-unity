# Integrating Unity 3D game engine within an Android App

This project covers the process of integrating a simple game made with Unity within a native Android Application.

![Demo Gif](https://i.imgur.com/PI26MA6.gif)

At the time of this writing, this has been successfully implemented with **Unity 5.6.3** and **Android Studio 2.3.3**.

### Objective

Integrate **Unity** within an **Android App**, play the game (made in Unity) within the App, and establish a way for **Communication** / **Data Transfer** between the two, i.e.,

1. From the Android App, **Start the game** and **Send** an initial score to Unity.
2. **Receive** the score in Unity (sent from Android). **Play the game** and increment the score. **Send** the final score back to Android.
3. **Get** the score from Unity and display it in Android.

### From Unity

I have made a simple game using Unity, in which, on clicking the **TAP** button once, the score increases by one. On clicking the **Finish** button, the game ends and the score is sent to Android (Communication details are below). Then I exported the project using **Gradle**.

### From Android Studio

I then opened this project using **Android Studio** (Import Gradle Project). You can convert this project into a library (Links are below) or build upon itself. I chose the latter option for this project. Unity creates the class *UnityPlayerActivity* for it's *UnityPlayer* in Android. This class is used for communicationg with Unity. I added more Activities to the Project, to execute the complete flow.

### Resources (What I followed and proved to be very helpful)

#### Detailed Guide to Embed Unity into Android

https://medium.com/@davidbeloosesky/embedded-unity-within-android-app-7061f4f473a


#### Communication : Android (Java) -> Unity (C#)

http://answers.unity3d.com/questions/610587/call-unity-apk-with-intent-and-read-extras.html

http://answers.unity3d.com/questions/366452/call-a-unity-script-function-from-android-java-cod.html

#### Communication : Unity (C#) -> Android (Java)

https://stackoverflow.com/questions/7749841/unity3d-integration-with-android

### Good Job ! You're good to go.

Now that you're done with all the boring stuff, you can now make any game or application using Unity and integrate in it in your Android App.