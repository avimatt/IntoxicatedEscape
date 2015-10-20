using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class startGame : MonoBehaviour {
	
	public GameObject repBarGO;
	public static bool playedOnce;
	public static bool startIntro;

	public static float time;

	void Start(){
		playedOnce = false;
		startIntro = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown) {
			resetNPCTags();
			ThrowUp.sound = false;
			gameObject.SetActive(false);
			Vector2 temp = new Vector2 (200, repBarGO.GetComponent<Image> ().rectTransform.sizeDelta.y);
			repBarGO.GetComponent<Image> ().rectTransform.sizeDelta = temp;
			repBarGO.GetComponent<Image> ().color = Color.green;
			Main.min = 1;
			Main.sec = 0;

			if(!playedOnce){
				GameObject.Find("introSound").GetComponent<AudioSource>().Play();
				time = Time.time;
				startIntro = true;
				playedOnce = true;
			} else {
				Main.playingGame = true;
			}
		}

		if (startIntro) {
			if(Time.time >= time + 13){
				Main.playingGame = true;
				startIntro = false;
			}
		}
	}

	void resetNPCTags(){
		GameObject[] hitNPCs = GameObject.FindGameObjectsWithTag ("NPC_hit");
		foreach (GameObject npc in hitNPCs) {
			npc.tag = "NPC";
		}
	}
}
