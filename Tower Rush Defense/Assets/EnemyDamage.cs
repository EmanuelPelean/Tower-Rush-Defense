using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

	
	void Start () {
		
	}
    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit!");
    }
}
