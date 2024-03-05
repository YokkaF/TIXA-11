using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPref;
    [SerializeField] private Transform SpawnAmmo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) {
            Instantiate(bulletPref, SpawnAmmo.position, SpawnAmmo.rotation);
        }
    }
}
