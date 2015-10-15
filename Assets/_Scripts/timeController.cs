using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class timeController : MonoBehaviour {

	public float min;
	public float sec;

	public GameObject time;

	// Update is called once per frame
	void Update () {
		sec -= Time.deltaTime;
		if (sec <= 0 && min <= 0) {
			endGame();
		}
		if (sec <= -.5f) {
			sec = 59;
			min -= 1;
		}
		time.GetComponent<Text> ().text = getTimeString (min) + ":" + getTimeString (sec);
	}

	string getTimeString(float val){
		if (val < 9.5f) {
			return "0" + val.ToString("0");
		}
		return val.ToString("0");
	}

	void endGame(){
		print ("gameOver");
	}

}
