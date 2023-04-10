using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaArma : MonoBehaviour
{
    public GameObject Ammo;
    public GameObject GunCannon;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            Instantiate(Ammo, GunCannon.transform.position, GunCannon.transform.rotation);
        }
    }
}
