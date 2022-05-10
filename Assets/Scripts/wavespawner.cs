using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float timeBetweenWaves = 10f;
    public Transform spawnPoint;
    public Text wavecountdowntext;
    public float countdown = 10f;
    private int waveIndex = 1;


    void Update()
    {
        if (countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        wavecountdowntext.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave(){
        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }
        waveIndex++;
    }

    void spawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

