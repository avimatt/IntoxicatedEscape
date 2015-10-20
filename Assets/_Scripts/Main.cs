using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Main : MonoBehaviour {

	public static float min;
	public static float sec;

	public GameObject time;
	public GameObject greenScreen;
	public GameObject loseScreenGO;
	public GameObject winScreenGO;
	public static bool playingGame;



	void Start() {
		loseScreenGO.SetActive (false);
		winScreenGO.SetActive (false);
		playingGame = false;
	}

	// Update is called once per frame
	void Update () {

		if (startGame.startIntro) {
			if(Time.time >= startGame.time + 11){
				Main.playingGame = true;
				startGame.startIntro = false;
			}
		}

		if (playingGame) {
			sec -= Time.deltaTime;
			if (sec <= 0 && min <= 0) {
				endGame ();
			}
			if (sec <= -.5f) {
				sec = 59;
				min -= 1;
			}
			time.GetComponent<Text> ().text = getTimeString (min) + ":" + getTimeString (sec);
		}
	}

	string getTimeString(float val){
		if (val < 9.5f) {
			return "0" + val.ToString("0");
		}
		return val.ToString("0");
	}

	void endGame(){
		playingGame = false;
		gameObject.transform.position = new Vector3(126.84f, -130f, 133.36f);
		loseScreenGO.SetActive (true);
	}

}
