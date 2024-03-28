using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    [SerializeField] private Bullet bulletPref;
    [SerializeField] private Transform SpawnAmmo;
    [SerializeField] private float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            var bullet = Instantiate(bulletPref, SpawnAmmo.position, SpawnAmmo.rotation);
            bullet.damage = damage;
        }
    }
}
