using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPick : MonoBehaviour {

    public GameObject playerGun;
    public GameObject groundGun;
    public GameObject UI;

    public int num = 1;

	// Use this for initialization
	void Start () {
        playerGun.SetActive(false);
        UI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        Ray ray;
        if (Physics.Raycast(transform.position, fwd, out hit, 5))
        {
            if (hit.collider.tag == "Skorpion VZ")
            {
                UI.SetActive(true);
                if (Input.GetKeyDown (KeyCode.E))
                {
                    groundGun.SetActive(false);
                    playerGun.SetActive(true);
                    playerGun.GetComponent<Weapon>().pickedUp = true;
                    playerGun.GetComponent<Weapon>().weaponNum = num;
                    GetComponent<WeaponSwitching>().selectedWeapon = num;
                    GetComponent<WeaponSwitching>().numOfWeapons++;
                    foreach (Transform weapon in transform)
                    {
                        int i = weapon.GetComponent<Weapon>().weaponNum;
                        if (i == num && weapon.GetComponent<Weapon>().pickedUp)
                            weapon.gameObject.SetActive(true);
                        else
                            weapon.gameObject.SetActive(false);

                    }
                    num++;
                    
                }
            }
            else
            {
                UI.SetActive(false);
            }
        }
        else
        {
            UI.SetActive(false);
        }
	}
}
