using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemySpawnScript : MonoBehaviour {

    public int grantHealth = 10;
    public GameObject enemy;

    public float waveTimer = 20f;
	// Use this for initialization
	void Start () {
        InvokeRepeating("spawnWave", 0, waveTimer);
	}

    void spawnWave()
    {
        if(grantHealth <= 0)
        {
            return;
        }
        EnemyGenetics eg = new EnemyGenetics();
        List<int[]> enemyType = eg.getEnemies();
        for (int i =0 ; i < 5; i++)
        {
            GameObject enemyi = Instantiate(enemy, transform.position,Quaternion.identity);
            enemyi.GetComponent<EnemyScript>().enemySpecs = enemyType.ElementAt(i);
        }
        
    }
	
    IEnumerator freezeTime()
    {
        yield return new WaitForSeconds(2f);
    }

	// Update is called once per frame
	void Update () {
		
	}

    

   
}
