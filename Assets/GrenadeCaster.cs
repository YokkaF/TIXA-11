using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float damage;
    [SerializeField] private Rigidbody rbGrenade;
    [SerializeField] private Transform SpawnGrenade;
    [SerializeField] private float force;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Grenade();
    }
    private void Grenade()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var greande = Instantiate(rbGrenade);
            greande.transform.position = SpawnGrenade.position;
            greande.GetComponent<Rigidbody>().AddForce(SpawnGrenade.forward * force);
            greande.GetComponent<Grenade>().damage = damage;
        }
    }
}
