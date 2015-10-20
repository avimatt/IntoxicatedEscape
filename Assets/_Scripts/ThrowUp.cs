using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class ThrowUp : MonoBehaviour {
	public static bool sound = false;
	// Use this for initialization
	void Update () {
		if (!sound) {
			GameObject.Find ("throwUp").GetComponent<AudioSource> ().Play ();
			sound = true;
		}
	}

}
