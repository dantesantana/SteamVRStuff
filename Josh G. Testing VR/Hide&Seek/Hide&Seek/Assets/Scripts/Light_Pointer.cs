using UnityEngine;
using System.Collections;

public class Light_Pointer : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}


	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Physics.Raycast (ray, out hit, Mathf.Infinity);
		this.transform.LookAt (hit.point);
		if (Input.GetKey (KeyCode.Mouse0)) {
			hit.rigidbody.AddForce (ray.direction * 1000.0f);
		}
	}
}
