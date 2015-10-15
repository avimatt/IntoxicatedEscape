using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lowerReputation : MonoBehaviour {

	public GameObject reputationBarGO;

	void OnControllerColliderHit(ControllerColliderHit hit){
		if(hit.gameObject.tag == "NPC"){
			Vector2 temp = new Vector2 (reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.x - 10, reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.y);
			reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta = temp;
			hit.gameObject.tag = "NPC_hit";
		}
	}
}
