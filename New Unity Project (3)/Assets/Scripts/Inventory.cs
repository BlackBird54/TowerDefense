using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject pistol;
    public GameObject rifle;
    public GameObject shotgun;

    private void Start()
    {
        rifle.GetComponent<SpriteRenderer>().enabled = false;
        rifle.GetComponent<Gun>().isActive = false;
        shotgun.GetComponent<SpriteRenderer>().enabled = false;
        shotgun.GetComponent<Gun>().isActive = false;
        pistol.GetComponent<SpriteRenderer>().enabled = true;
        pistol.GetComponent<Gun>().isActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            rifle.GetComponent<SpriteRenderer>().enabled = false;
            rifle.GetComponent<Gun>().isActive = false;
            shotgun.GetComponent<SpriteRenderer>().enabled = false;
            shotgun.GetComponent<Gun>().isActive = false;
            pistol.GetComponent<SpriteRenderer>().enabled = true;
            pistol.GetComponent<Gun>().isActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            shotgun.GetComponent<SpriteRenderer>().enabled = false;
            shotgun.GetComponent<Gun>().isActive = false;
            pistol.GetComponent<SpriteRenderer>().enabled = false;
            pistol.GetComponent<Gun>().isActive = false;
            rifle.GetComponent<SpriteRenderer>().enabled = true;
            rifle.GetComponent<Gun>().isActive = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            rifle.GetComponent<SpriteRenderer>().enabled = false;
            rifle.GetComponent<Gun>().isActive = false;
            pistol.GetComponent<SpriteRenderer>().enabled = false;
            pistol.GetComponent<Gun>().isActive = false;
            shotgun.GetComponent<SpriteRenderer>().enabled = true;
            shotgun.GetComponent<Gun>().isActive = true;
        }
    }
}
