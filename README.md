# Integrating Unity 3D game engine within an Android App

This project covers the process of integrating a game made with Unity within a native Android Application.

<img src="https://i.imgur.com/PI26MA6.gif" width="500px" />

## Objective

Integrate a **Unity Game** within an **Android App**, and establish a way for **Communication** / **Data Transfer** between the two, i.e.,

1. From the Android App, **Start the game** and **Send** an initial score to Unity.
2. **Receive** the score in Unity. **Play the game** and increment the score. **Send** the final score back to Android.
3. Back in Android, **Get** the score from Unity and finally display it.

## Getting Started

### Unity

I have made a simple game using Unity, in which the score increments on clicking the **TAP** button. On clicking the **Finish** button, the game ends. Then I exported the project using **Gradle**.

### Android Studio

I then opened this project using **Android Studio** (Import Gradle Project). You can either convert this project into an **Android Archive Library (AAR)** and import it in your own Android Studio project or you can modify this project itself. I chose the latter option for this project. Unity creates the **UnityPlayerActivity**, containing the **UnityPlayer**, in Android. This class is used for all communications with Unity. I added more Activities to the Project, to execute the complete flow.


**For more info:** [Detailed Guide to Embed Unity into Android](https://medium.com/@davidbeloosesky/embedded-unity-within-android-app-7061f4f473a)

## Communication / Data Transfer

### 1. Android (Java) -> Unity (C#)

**In Android**, start the *UnityPlayerActivity* from your Activity with an Intent and add data to this intent using `putExtra`
```
Intent intent = new Intent(this, UnityPlayerActivity.class);
intent.putExtra("arguments", 50);
startActivity(intent);
```

**In Unity**, retrieve the data from the Intent as shown below
```
int tap_count;

void Start () {
	AndroidJavaClass UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
	AndroidJavaObject currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>	("currentActivity");

	AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
	bool hasExtra = intent.Call<bool> ("hasExtra", "arguments");

	if (hasExtra) {
		AndroidJavaObject extras = intent.Call<AndroidJavaObject> ("getExtras");
		tap_count = extras.Call<int> ("getInt", "arguments");
	}
}
```

### 2. Unity (C#) -> Android (Java)

**In Android**, create a method in *UnityPlayerActivity* to receive data from Unity. This method can be directly called from Unity as shown in the next section
``` 
public void onGameFinish(int score) {
	Intent resultIntent = new Intent(this, ResultActivity.class);
    resultIntent.putExtra("score", score);
    startActivity(resultIntent);
}
```

**In Unity**, call the method defined in the *UnityPlayerActivity* with the arguments
```
currentActivity.Call("onGameFinish", tap_count);
```

## Built With

- [Unity 5.6.3](https://unity3d.com/)
- [Android Studio 2.3.3](https://developer.android.com/studio/index.html)

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details