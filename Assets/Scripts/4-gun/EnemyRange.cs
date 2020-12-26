using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


// This component represents an enemy movement to given target
// using NavMeshAgent.

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyRange : MonoBehaviour
{

    private Transform target;

    private NavMeshAgent navMeshAgent;
    [SerializeField] private float MovementSpeed = 10f;

    [SerializeField] private float rotationSpeed = 5f;

    [SerializeField] float enemyChaseRange =100f;

    [SerializeField] float enemyshootRange = 50f;

    [SerializeField] float enemyshootDemage = 1f;

    [SerializeField] float timeBetweenShoot = 2000f;

    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);


        if (distance <= enemyChaseRange)
        {
            if (distance <= enemyshootRange)
            {
                this.StartCoroutine(shoot());

            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), rotationSpeed * Time.deltaTime);
            transform.position += transform.forward * MovementSpeed * Time.deltaTime;
        }
        
       
    }

    private IEnumerator shoot()
    {
        yield return new WaitForSecondsRealtime(timeBetweenShoot);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, enemyshootRange))
        {
            GunTarget target = hit.transform.GetComponent<GunTarget>();
            if (target != null)
            {
                target.takeDamage(enemyshootDemage);
            }
            
            GameObject g = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(g, 1f);
        }


    }
}