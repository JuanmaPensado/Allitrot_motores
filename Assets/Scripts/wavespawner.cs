using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public static int EnemiesAlive;
    public float countdown = 10f;
    public float timeBetweenWaves = 10f;
    public float spawnrate = 2f;
    public Transform Estandard_enemyPrefab;
    public Transform Quick_enemyPrefab;
    public Transform Tank_enemyPrefab;
    public Transform spawnPoint;
    public Text wavecountdowntext;
    private int waveIndex = 1;

    void Start(){
        EnemiesAlive = 0;
    }

    void Update()
    {

        if (EnemiesAlive > 0) return;
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        wavecountdowntext.text = string.Format("Wave {0:00}\n"+"{1:00.00}",waveIndex,countdown);
    }

    IEnumerator SpawnWave(){
        
        playerStats.Rounds++;
        int tamañoWave = Random.Range(waveIndex, waveIndex*2);
        Transform enemigo = Estandard_enemyPrefab ;
        
        for (int i = 0; i < tamañoWave; i++)
        {

            if(waveIndex >= 5){
                int numenemigo = Random.Range(0,3);
                if (numenemigo == 0) enemigo = Estandard_enemyPrefab;
                if (numenemigo == 1) enemigo = Quick_enemyPrefab;
                if (numenemigo == 2) enemigo = Tank_enemyPrefab;

                spawnEnemy(enemigo);
                yield return new WaitForSeconds(spawnrate);
                
            }
            else if(waveIndex >=3){
                int numenemigo = Random.Range(0,2);
                if (numenemigo == 0) enemigo = Estandard_enemyPrefab;
                if (numenemigo == 1) enemigo = Quick_enemyPrefab;

                spawnEnemy(enemigo);
                yield return new WaitForSeconds(spawnrate);
            }
            else{

                spawnEnemy(enemigo);
                yield return new WaitForSeconds(spawnrate);
            }
            
        }
        
        waveIndex++;
    }

    void spawnEnemy(Transform enemigo){
        Instantiate(enemigo, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}

