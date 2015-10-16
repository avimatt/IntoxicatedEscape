using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float actualMoveSpeed;
	public GameObject cameraGO;

	CharacterController cc;
	public bool leaningLeft;
	public bool leaningRight;
	public bool correctingAngle;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		correctingAngle = false;
	}
	
	// Update is called once per frame
	void Update () {

		//Movement
		float sideSpeed = Input.GetAxis ( "Horizontal" ) * actualMoveSpeed;
		Vector3 angles = cameraGO.transform.rotation.eulerAngles;

		if (sideSpeed > 0) { // Lean to the right
			if(isLegalRotation (sideSpeed)){
				if(correctingAngle){
					angles[2] = Mathf.Round(angles[2]);
					cameraGO.transform.rotation = Quaternion.Euler(angles);
					correctingAngle = false;
				}

				cameraGO.transform.Rotate (0, 0, -1);
				angles[2] = cameraGO.transform.rotation.eulerAngles[2];

				leaningRight = angles[2] >= 340 && angles[2] <= 360; 
				leaningLeft = angles[2] >= 0 && angles[2] <= 20; 
			}
		} else if (sideSpeed < 0) { // Lean to the left
			if(isLegalRotation (sideSpeed)){
				if(correctingAngle){
					angles[2] = Mathf.Round(angles[2]);
					cameraGO.transform.rotation = Quaternion.Euler(angles);
					correctingAngle = false;
				}

				cameraGO.transform.Rotate (0, 0, 1);
				angles[2] = cameraGO.transform.rotation.eulerAngles[2];

				leaningLeft = angles[2] >= 0 && angles[2] <= 20; 
				leaningRight = angles[2] >= 340 && angles[2] <= 360; 
			}
		} else { // When not moving 

			if(leaningLeft){
				correctingAngle = true;
				angles[2] = angles[2] - (angles[2] * .03f);
				cameraGO.transform.rotation = Quaternion.Euler(angles);
				if(cameraGO.transform.rotation.eulerAngles[2] < 0.009){
					leaningLeft = false;
				}
			} 
			if(leaningRight) {
				correctingAngle = true;
				angles[2] = angles[2] + ((360 - angles[2]) * .03f);
				cameraGO.transform.rotation = Quaternion.Euler(angles);

				if(cameraGO.transform.rotation.eulerAngles[2] < 0.009){
					leaningRight = false;
				}
			}

		}

		Vector3 speed = new Vector3 ( -1.5f, 0, sideSpeed );
		cc.SimpleMove( speed );

	}

	bool isLegalRotation(float sideSpeed){
		Vector3 angles = cameraGO.transform.rotation.eulerAngles;
		if (sideSpeed > 0) {
			float zAngle = angles[2] - 1 <= 0 ? 360 : angles[2] - 1;
			if ((zAngle >= 340 && zAngle <= 360) || (zAngle <= 20 && zAngle >= 0)) {
				return true;
			}
		}
		if (sideSpeed < 0) {
			float zAngle = angles[2] + 1 >= 360 ? 0 : angles[2] + 1;
			if ((zAngle >= 340 && zAngle <= 360) || (zAngle <= 20 && zAngle >= 0)) {
				return true;
			}
		}
		return false;
	}


}