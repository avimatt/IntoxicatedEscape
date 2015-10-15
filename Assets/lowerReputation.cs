using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lowerReputation : MonoBehaviour {

	public GameObject reputationBarGO;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision){
		if(collision.collider.CompareTag("Player")){
			Vector2 temp = new Vector2 (10, reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta.y);
			reputationBarGO.GetComponent<Image> ().rectTransform.sizeDelta = temp;
		}
	}
}
