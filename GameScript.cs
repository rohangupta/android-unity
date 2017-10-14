using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour {

	AndroidJavaClass UnityPlayer;
	AndroidJavaObject currentActivity;

	int args;

	int tap_count;

	[SerializeField]
	private Text score;

	void Start () {
		tap_count = 0;

		UnityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"); 
		currentActivity = UnityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

		AndroidJavaObject intent = currentActivity.Call<AndroidJavaObject>("getIntent");
		bool hasExtra = intent.Call<bool> ("hasExtra", "arguments");

		if (hasExtra) {
			AndroidJavaObject extras = intent.Call<AndroidJavaObject> ("getExtras");
			args = extras.Call<int> ("getInt", "arguments");

			score.text = "" + args;
			tap_count = args;
		}
	}

	void Update () {
		
	}

	public void buttonTapped() {

		tap_count += 1;
		score.text = "" + tap_count;
	}

	public void buttonFinish() {
		//Application.Quit ();
		currentActivity.Call("onGameFinish", tap_count);
	}
}
