using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public static int EnemiesAlive = 0;
    public float countdown = 10f;
    public float timeBetweenWaves = 10f;
    public float spawnrate = 2f;
    public Transform Estandard_enemyPrefab;
    public Transform Quick_enemyPrefab;
    public Transform Tank_enemyPrefab;
    public Transform spawnPoint;
    public Text wavecountdowntext;
    private int waveIndex = 1;


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

        wavecountdowntext.text = string.Format("{0:00.00}",countdown);
    }

    IEnumerator SpawnWave(){
        
        playerStats.Rounds++;
        int tamañoWave = Random.Range(waveIndex, waveIndex*2);
        Transform enemigo = Estandard_enemyPrefab ;
        Debug.Log(waveIndex+","+tamañoWave);
        
        for (int i = 0; i < tamañoWave; i++)
        {

            if(waveIndex >= 5){
                int numenemigo = Random.Range(0,3);
                if (numenemigo == 0) enemigo = Estandard_enemyPrefab;
                if (numenemigo == 1) enemigo = Quick_enemyPrefab;
                if (numenemigo == 2) enemigo = Tank_enemyPrefab;
                Debug.Log(">=5, " + numenemigo );
                spawnEnemy(enemigo);
                yield return new WaitForSeconds(spawnrate);
                
            }
            else if(waveIndex >=3){
                int numenemigo = Random.Range(0,2);
                if (numenemigo == 0) enemigo = Estandard_enemyPrefab;
                if (numenemigo == 1) enemigo = Quick_enemyPrefab;
                Debug.Log(">=3, " + numenemigo );
                spawnEnemy(enemigo);
                yield return new WaitForSeconds(spawnrate);
            }
            else{
                Debug.Log("else");
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

