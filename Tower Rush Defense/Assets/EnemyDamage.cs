using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 20;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamageSFX;
    [SerializeField] AudioClip enemyDeathSFX;
    private EnemySpawner enemySpawner;
    AudioSource audioSource;
    void Start () {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.PlayOneShot(enemyDamageSFX);
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
    }
}
