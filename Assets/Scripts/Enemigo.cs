using UnityEngine;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public float vel = 10f;    
    public int monedas = 25;
    public float Starthealth = 100;
    private float health;
    private Transform target;
    private int waypointIndex = 0;
    public GameObject deathEffect;


    public Image HealthBar;

    void Start()
    {
        target = Waypoints.points[0];
        health = Starthealth;
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * vel * Time.deltaTime, Space.World);

        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime*5f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f,rotation.y,0f);
        
        if (Vector3.Distance(transform.position, target.position) <= 0.4f){
            GetNextWaypoint();
        }
        
    }

    void GetNextWaypoint(){
        if (waypointIndex >= Waypoints.points.Length - 1){

            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    void EndPath (){
        playerStats.Lives--;
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);
        wavespawner.EnemiesAlive--;

    }

    public void TakeDamage(int amount){
        health -= amount;

        HealthBar.fillAmount= health / Starthealth;
        if (health <=0){
            Die();
        }
    }

    void Die(){
        GameObject effect = (GameObject) Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(effect, 5f);
        playerStats.Currency += monedas; // CAMBIAR
        wavespawner.EnemiesAlive--;
    }
}
