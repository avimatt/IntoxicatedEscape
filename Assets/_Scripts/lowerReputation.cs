using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lowerReputation : MonoBehaviour {

	public GameObject reputationBarGO;

	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "NPC"){
			float width = reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.x - 10;
			Vector2 temp = new Vector2 (width, reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.y);
			reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta = temp;
			SetColor(width);
			hit.gameObject.tag = "NPC_hit";
		}
	}

	void SetColor(float width) {
		if (width > 80) {
			reputationBarGO.GetComponent<Image> ().color = Color.green; // green
		} else if (width > 50) {
			reputationBarGO.GetComponent<Image> ().color = Color.yellow; // yellow
		} else {
			reputationBarGO.GetComponent<Image> ().color = Color.red; // red
		}
	}
}
