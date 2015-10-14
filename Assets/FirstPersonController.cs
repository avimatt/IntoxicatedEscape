using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

	public float actualMoveSpeed;
	public GameObject cameraGO;

	float _sideSpeed;
	CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		//Movement
		float sideSpeed = Input.GetAxis ( "Horizontal" ) * actualMoveSpeed;

		//TODO make sure you can't rotate 360 degrees
		if (sideSpeed > 0) {
			cameraGO.transform.Rotate (0, 0, -2);
		} else if (sideSpeed < 0) {
			cameraGO.transform.Rotate (0, 0, 2);
		}

		_sideSpeed = sideSpeed != 0 ? sideSpeed : _sideSpeed;
		Vector3 speed = sideSpeed == 0 ? new Vector3 ( -1.5f, 0, _sideSpeed * 10 ) : new Vector3 ( -1.5f, 0, _sideSpeed );

		cc.SimpleMove( speed );

	}

	void FixedUpdate () {

		// have the camera shake a bit when tilted (doesn't quite work yet)
		float shackyCoefficient = 0; 
		if( cameraGO.transform.rotation[2] < 0 ){
			shackyCoefficient = cameraGO.transform.rotation[2] + Random.Range(0f, 4f);
		} else if ( cameraGO.transform.rotation[2] < 0 ) {
			shackyCoefficient = cameraGO.transform.rotation[2] + Random.Range(-4f, 0f);
		}
		cameraGO.transform.Rotate (0, 0, shackyCoefficient);
	}

}