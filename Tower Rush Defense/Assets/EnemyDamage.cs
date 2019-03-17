using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 20;
    [SerializeField] Collider collisionMesh;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
	void Start () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void KillEnemy()
    {
        // important to instantiate before destroying this object
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        hitParticlePrefab.Play();
        print("current hitpoints are " + hitPoints);
    }
}
