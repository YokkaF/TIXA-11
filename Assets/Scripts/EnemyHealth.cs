using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private PlayerProgress playerProgress;
    public float healthValue;
    [SerializeField] private float expboost;
    void Start()
    {

    }

    // Update is called once per frame
    public void DealDamage(float damage)
    {

        healthValue -= damage;
        playerProgress.AddExp(damage);
        if (healthValue <= 0) {
            playerProgress.AddExp(expboost);
            EnemyDeath(); 
        }
        
    }
    private void EnemyDeath()
    {
        Destroy(gameObject);
    }
}
