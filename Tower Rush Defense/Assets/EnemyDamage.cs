using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] int hitPoints = 20;
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
        Destroy(gameObject);
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("current hitpoints are " + hitPoints);
    }
}
