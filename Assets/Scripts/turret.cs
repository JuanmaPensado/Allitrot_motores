using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    
    [Header("Attributes")]
    public float range = 15f;
    public float firerate = 1f;
    private float firecountdown = 0f;
   
    [Header("Unity Setup")]
    public string enemyTag = "Enemy";
    
    public Transform rotator;
    public float rotationSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firepoint;


    void Start(){
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    // Update is called once per frame
    void Update(){
        
        if (target == null){
            return;
        }

        //target lock on
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotator.rotation, lookRotation, Time.deltaTime*rotationSpeed).eulerAngles;
        rotator.rotation = Quaternion.Euler(0f,rotation.y,0f);

        //fire
        if (firecountdown <= 0f ){
            Shoot();
            firecountdown = 1f/firerate;
        }
        firecountdown -= Time.deltaTime;
    }

    void UpdateTarget(){
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceEnemy < shortestDistance){
                shortestDistance = distanceEnemy;
                nearestEnemy = enemy;
            }

        }

        if (nearestEnemy != null && shortestDistance <= range){
            target = nearestEnemy.transform;
        }
        else{
            target = null;
        }
    }

    void Shoot(){
        GameObject bulletGO = Instantiate(bulletPrefab,firepoint.position,firepoint.rotation);
        bullet bullet = bulletGO.GetComponent<bullet>();

        if(bullet != null){
            bullet.spawn(target);
        }
    }
    void OnDrawGizmosSelected (){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
