using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class collisionHandler : MonoBehaviour {

	public GameObject reputationBarGO;
	public GameObject winScreenGO;
	public GameObject resultTextGO;

	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "NPC"){
			GameObject.Find("bumpSound").GetComponent<AudioSource>().Play();
			float width = reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.x - 25;
			if(width < 0) width = 0;
			Vector2 temp = new Vector2 (width, reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.y);
			reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta = temp;
			SetColor(width);
			hit.gameObject.tag = "NPC_hit";
		}
		if (hit.gameObject.tag == "Finish") {
			Main.playingGame = false;
			gameObject.transform.position = new Vector3(126.84f, -130f, 133.36f);
			winScreenGO.SetActive(true);
			setResultText();
		}
	}

	void SetColor(float width) {
		if (width > 90) {
			reputationBarGO.GetComponent<Image> ().color = Color.green; // green
		} else if (width > 50) {
			reputationBarGO.GetComponent<Image> ().color = Color.yellow; // yellow
		} else {
			reputationBarGO.GetComponent<Image> ().color = Color.red; // red
		}
	}

	void setResultText(){
		string resultText = "";
		float width = reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.x;
		if (width < 50) {
			resultText = "You weren't descrete and you have been ostrasized from you friend group";
		} else if (width < 90) {
			resultText = "Some people noticed but no one will remember this in a couple of days";
		} else if (width < 200) {
			resultText = "Almost no one noticed how drunk you were. Way to go!";
		} else if (width == 200){
			resultText = "They should call you a ninja because no one saw you at all";
		}
		resultTextGO.GetComponent<Text> ().text = resultText;
	}
}
