using UnityEngine;
using System.Collections;

public class MouseCam : MonoBehaviour {

	private float rotX = 0.0f;
	private float rotY = 0.0f;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		rotX = transform.localEulerAngles.y + Input.GetAxis ("Mouse X") * 1.0f;
		rotY += Input.GetAxis ("Mouse Y");
		rotY = Mathf.Clamp (rotY, -60.0f, 60.0f);
		transform.localEulerAngles = new Vector3 (-rotY, rotX, 0.0f);
	}
}
