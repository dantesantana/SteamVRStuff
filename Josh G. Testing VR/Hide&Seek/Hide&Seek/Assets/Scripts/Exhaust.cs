using UnityEngine;
using System.Collections;

public class Exhaust : MonoBehaviour {
	private float birthTime;
	private float currentTime;
	// Use this for initialization
	void Start () {
		birthTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - birthTime > 3.0f) {
			Destroy (this.gameObject);
		}
	}
}
