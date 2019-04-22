using UnityEngine;
using System.Collections;

public class TestControlScript : MonoBehaviour {

	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip;
	public GameObject projectile;
	public GameObject shotSpawn;
	//public GameObject launcher;
	private bool gripButtonDown = false;
	private bool gripButtonUp = false;
	private bool gripButtonPressed = false;

	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;
	private bool triggerButtonDown = false;
	private bool triggerButtonUp = false;
	private bool triggerButtonPressed = false;

	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } }
	private SteamVR_TrackedObject trackedObj;

	// Use this for initialization
	void Start () {
		trackedObj = GetComponent<SteamVR_TrackedObject> ();
	
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
			Instantiate (projectile,this.transform.position, shotSpawn.transform.rotation);
		}
		if (triggerButtonUp) {
			Debug.Log ("Trigger Button unpressed");
		}

	}
}
