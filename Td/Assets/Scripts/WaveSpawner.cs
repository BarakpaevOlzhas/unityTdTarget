using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform enemyPrefab;

    [SerializeField]
    private Transform spawnPoint;

    [SerializeField]
    private float timeBetweenWaves;

    [SerializeField]
    private Text countdownText;

    private float countdownTimer;

    private int waveNumber;

    void Start()
    {
        countdownTimer = timeBetweenWaves;
    }
    
    void Update()
    {
        if (countdownTimer <= 0)
        {
            StartCoroutine(SpawnWave());
            countdownTimer = timeBetweenWaves;
        }

        countdownTimer -= Time.deltaTime;

        countdownText.text = countdownTimer.ToString("0");
    }

    private IEnumerator SpawnWave()
    {
        waveNumber++;
        for (int i = 0; i < waveNumber; i++) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1.5f);
        }        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position,spawnPoint.rotation);
    }
}
