using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private bool _isPlayerNoticed;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private List<Transform> points;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private PlayerController player;
    [SerializeField] private float damage;
    [SerializeField] private float viewAngle;
    private void Start()
    {
        PointPick();
    }
    void Update()
    {

        noticePlayerUpdate();
        PointPickUpdate();
        ChaseUpdate();
        AttackUpdate();


    }




    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) {
                playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
    private void PointPick()
    {
        _navMeshAgent.destination = points[Random.Range(0, points.Count)].position;
    }
    private void PointPickUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance) 
            {
                PointPick();
            }
               
        }
    }
    private void noticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }

            }

        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed) {
            _navMeshAgent.destination = player.transform.position;
        }
    }
   
}

