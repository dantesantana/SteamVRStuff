using UnityEngine;
using System.Collections;

public class TestControlScript : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	private Rigidbody rb;
	public GameObject cameraRig;
	public GameObject forceVector;
	//public GameObject projectile;
	//public GameObject shotSpawn;
	//public GameObject launcher;
	public bool gripButtonDown = false;
	public bool gripButtonUp = false;
	public bool gripButtonPressed = false;

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	public bool triggerButtonDown = false;
	public bool triggerButtonUp = false;
	public bool triggerButtonPressed = false;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	private SteamVR_TrackedObject trackedObj;

	private float speed = 30.0f;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
		rb = cameraRig.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller == null){
			Debug.Log ("Controller not initialized");
			return;
		}
		gripButtonDown = controller.GetPressDown(gripButton);
		gripButtonUp = controller.GetPressUp(gripButton);
		gripButtonPressed = controller.GetPress(gripButton);

		triggerButtonDown = controller.GetPressDown(triggerButton);
		triggerButtonUp = controller.GetPressUp(triggerButton);
		triggerButtonPressed = controller.GetPress(triggerButton);

		if(gripButtonDown){
			Debug.Log ("Grip Button Pressed");
		}
		if (gripButtonUp) {
			Debug.Log ("Grip Button unpressed");
		}
		if(triggerButtonDown){
			Debug.Log ("Trigger Button Pressed");
			rb.AddForce (forceVector.transform.up * speed);
			//Instantiate (projectile,this.transform.position, shotSpawn.transform.rotation);
		}
		if (triggerButtonUp) {
			Debug.Log ("Trigger Button unpressed");
		}

	}
}
