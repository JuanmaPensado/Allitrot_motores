using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class wavespawner : MonoBehaviour
{
    [Header ("Attributes")]
    public float countdown = 10f;
    public float timeBetweenWaves = 10f;
    public float spawnrate = 2f;

    [Header("Unity Setup")]
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text wavecountdowntext;
    private int waveIndex = 1;


    void Update()
    {
        if (countdown <= 0f){
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        wavecountdowntext.text = "Next wave in : " + Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave(){
        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnemy();
            yield return new WaitForSeconds(spawnrate);
        }
        waveIndex++;
    }

    void spawnEnemy(){
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

