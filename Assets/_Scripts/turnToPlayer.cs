using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class turnToPlayer : MonoBehaviour {

	GameObject repBar;
	GameObject playerController;
	float width;

	// Use this for initialization
	void Start () {
		repBar = GameObject.Find ("ReputationBar");
	}
	
	// Update is called once per frame
	void Update () {
		width = repBar.GetComponent<Image> ().rectTransform.sizeDelta.x;
		if (width < 50) {
			TurnNPCtoPlayer();
		}
	}

	void TurnNPCtoPlayer() {

		playerController = GameObject.Find ("Player");
		float angle = 90f;
		if (playerController.transform.position [2] > gameObject.transform.position [2]) {
			angle = GetAngleLeft(playerController.transform.position, gameObject.transform.position);
			SetAngle(angle);
		} else if (playerController.transform.position [2] < gameObject.transform.position [2]) {
			angle = GetAngleRight(playerController.transform.position, gameObject.transform.position);
			SetAngle(angle);
		} else {
			SetAngle(angle);
		}

	}

	float GetAngleLeft(Vector3 player, Vector3 npc) {
		return -1 * Mathf.Atan2(npc[0] - player[0], player[2] - npc[2]) * Mathf.Rad2Deg; 
	}

	float GetAngleRight(Vector3 player, Vector3 npc) {
		return 180 + (Mathf.Atan2(npc[0] - player[0], npc[2] - player[2]) * Mathf.Rad2Deg); 
	}

	void SetAngle(float angle){
		Vector3 rotation = new Vector3 (0, angle, 0);
		gameObject.transform.rotation = Quaternion.Euler(rotation);
	}

}
