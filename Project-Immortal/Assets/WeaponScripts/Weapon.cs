using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {


    public bool pickedUp;

    public int weaponNum;

    public float range = 100f;
    public int bulletsPer = 20;
    public int bulletsRemaining;
    public bool isMelee;
    public Transform shootPoint;

    public float coolDown = 0.1f;
    public float reloadCD = 1.5f;
    float timer;
    float timerReload;

	// Use this for initialization
	void Start () {
        if (!isMelee)
        {
            bulletsRemaining = bulletsPer;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		if (!isMelee)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
            if (timerReload < reloadCD)
            {
                timerReload += Time.deltaTime;
            }
        }
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }

        

        

        if (timer < coolDown)
        {
            timer += Time.deltaTime;
        }

	}

    void Fire()
    {
        if (!isMelee)
        {
            if (timer >= coolDown && bulletsRemaining > 0)
            {
                timer = 0.0f;
                RaycastHit hit;
                if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name + " found!");
                    
                }
                bulletsRemaining--;
            }
        }
        else
        {
            if (timer >= coolDown)
            {
                timer = 0.0f;
                RaycastHit hit;
                if (Physics.Raycast(shootPoint.position, shootPoint.transform.forward, out hit, range))
                {
                    Debug.Log(hit.transform.name + " found!");
                }
            }
        }
    }

    void Reload()
    {
        if (timerReload >= reloadCD && bulletsRemaining < bulletsPer)
        {
            timer = -timerReload;
            timerReload = 0.0f;
            bulletsRemaining = bulletsPer;
            Debug.Log("Reload!");
        }
    }
}
