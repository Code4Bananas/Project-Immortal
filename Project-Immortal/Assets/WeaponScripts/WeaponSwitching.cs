using UnityEngine;

public class WeaponSwitching : MonoBehaviour {

    public int selectedWeapon = 0;
    public int numOfWeapons = 1;
	// Use this for initialization
	void Start () {
        SelectWeapon();
	}
	
	// Update is called once per frame
	void Update () {
        int previousSelectedWeapon = selectedWeapon;
		if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= numOfWeapons-1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = numOfWeapons-1;
            else
                selectedWeapon--;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && numOfWeapons >= 2)
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && numOfWeapons >= 3)
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && numOfWeapons >= 4)
        {
            selectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && numOfWeapons >= 5)
        {
            selectedWeapon = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && numOfWeapons >= 6)
        {
            selectedWeapon = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && numOfWeapons >= 7)
        {
            selectedWeapon = 6;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
	}

    void SelectWeapon ()
    {
        
        foreach (Transform weapon in transform)
        {
            int i = weapon.GetComponent<Weapon>().weaponNum;
            if (i == selectedWeapon && weapon.GetComponent<Weapon>().pickedUp)
            {
                weapon.gameObject.SetActive(true);
                weapon.GetComponent<Weapon>().isActive = true;
            }
                
            else
            {
                weapon.gameObject.SetActive(false);
                weapon.GetComponent<Weapon>().isActive = false;
            }
                
            
        }
    }
}
