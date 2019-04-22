using UnityEngine;
using System.Collections;

public class Glider : MonoBehaviour {
	//public GameObject rotatingBody;
	public GameObject leftForceVector;
	public GameObject rightForceVector;
	public GameObject leftController;
	public GameObject rightController;

	public GameObject exhaustPrefab;

	private Renderer rndL;
	private Renderer rndR;

	private float speed = 10.0f;
	private float minVel = -60.0f;
	private float maxVel = 30.0f;

	private bool thrustOnL = false;
	private bool thrustOnR = false;

	private Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rndL = leftForceVector.GetComponent<Renderer> ();
		rndR = rightForceVector.GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (leftController.GetComponent<TestControlScript>().triggerButtonDown) {
			thrustOnL = !thrustOnL;
		}
		if (thrustOnL) {
			rb.AddForce (leftController.transform.forward * -speed);
			rndL.material.color = Color.red;
			Instantiate (exhaustPrefab, leftController.transform.position, leftController.transform.rotation);
		} else {
			rndL.material.color = Color.blue;
		}

		if (rightController.GetComponent<TestControlScript>().triggerButtonDown) {
			thrustOnR = !thrustOnR;
		}
		if (thrustOnR) {
			rb.AddForce (rightController.transform.forward * -speed);
			rndR.material.color = Color.red;
			Instantiate (exhaustPrefab, rightController.transform.position, rightController.transform.rotation);
		} else {
			rndR.material.color = Color.blue;
		}

//		if (leftController.GetComponent<TestControlScript>().triggerButtonDown) {
//			thrustOnR = !thrustOnR;
//		}
//
//		if (thrustOnL) {
//			rb.AddForce (leftController.transform.forward * speed);
//			leftForceVector.GetComponent<Material> ().color = Color.red;
//		} else {
//			//leftForceVector.getcom
//		}

		//limit each axis of velocity between min and max velocity
		float x = Mathf.Clamp(rb.velocity.x, minVel, maxVel);
		float y = Mathf.Clamp(rb.velocity.y, /*Mathf.Infinity * -1.0f*/ minVel, maxVel);
		float z = Mathf.Clamp(rb.velocity.z, minVel, maxVel);

		rb.velocity = new Vector3 (x, y, z);
	
//		Debug.Log (thrustOnL);
//		Debug.Log (thrustOnR);
		//Debug.Log(rb.velocity);
	}
}
