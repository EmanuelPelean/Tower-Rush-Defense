using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 20;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    private EnemySpawner enemySpawner;

    void Start () {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    private void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        enemySpawner.AddScore();
        // important to instantiate before destroying this object
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

   

    private void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
}
