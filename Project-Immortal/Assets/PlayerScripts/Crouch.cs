using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Crouch : MonoBehaviour {
    public bool check;
    private CharacterController character;
    private float prevWalk;
    FirstPersonController fpc;

    // Use this for initialization
    void Start () {
        character = GetComponent<CharacterController>();
        prevWalk = 5f;

        fpc = GameObject.FindObjectOfType<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(character.height);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            fpc.m_WalkSpeed = 3f;
            character.height = 1.00f; //crouch height
            //transform.position = new Vector3(transform.position.x, transform.position.y - 0.1f, transform.position.z);
        }
        else
        {
            fpc.m_WalkSpeed = 5f;
            character.height = 1.8f; //player height
                                      //transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
        }
    }
}
