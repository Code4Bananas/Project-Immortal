using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

    public Light flashlight;
    public bool onOff;

	// Use this for initialization
	void Start () {
        flashlight = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        flashlight.enabled = onOff;
		if (Input.GetKeyDown(KeyCode.F))
        {
            onOff = !onOff;
        }
	}
}
