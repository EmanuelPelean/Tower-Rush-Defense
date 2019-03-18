using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemySpawner : MonoBehaviour {
    [Range(0.1f, 120f)]
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Transform enemyParentTransform;
    [SerializeField] Text wave;
    [SerializeField] AudioClip spawnedEnemySFX;
    private int enemyWave;

    [SerializeField] Text currentScore;
    private int enemyKills;

    void Start () {
        StartCoroutine(RepeatedlySpawnEnemies());
        wave.text = enemyWave.ToString();
        currentScore.text = enemyKills.ToString();
    }
	
	IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // forever
        {
            Vector3 spawnPos = new Vector3(0, 0, 40);
            AddWave();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemy.transform.parent = enemyParentTransform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddWave()
    {
        enemyWave++;
        wave.text = enemyWave.ToString();
    }

    public void AddScore()
    {
        enemyKills++;
        currentScore.text = enemyKills.ToString();
    }
}
