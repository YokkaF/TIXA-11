using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float damage;

    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }


    // Update is called once per frame
    void Update()
    {
    
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        var enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.healthValue -= damage;
        }
        DestroyBullet();
         if (enemyHealth.healthValue <= 0)
            {
                Destroy(enemyHealth.gameObject);
            }
        
    }
    private void DestroyBullet() 
    {
        
        Destroy(gameObject);
    }
}
