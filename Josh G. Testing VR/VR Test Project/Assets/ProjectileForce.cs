using UnityEngine;
using System.Collections;

public class ProjectileForce : MonoBehaviour {
	private float thrust = 100.0f;
	private float lifeTime = 3.0f;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody> ().AddForce (this.transform.up * thrust);
	}
	
	// Update is called once per frame
	void Update () {
		//Destroy (gameObject, lifeTime);
	}
}
