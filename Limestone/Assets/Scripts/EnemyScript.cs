using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject split;
    public bool flying = false;
    public int enemyHealth = 5;
    public int movementSpeed = 1;
    public int scoreVal = 10;
    public bool splitter = false;
    public int[] enemySpecs;
    private bool first = true;

    void generateEnemy()
    {
        if (enemySpecs[0] == 1)
            flying = true;
        else if (enemySpecs[1] == 1)
            enemyHealth = 10;
        else if (enemySpecs[2] == 1)
            movementSpeed = 2;
        else if (enemySpecs[3] == 1)
            splitter = true;
    }
	// Use this for initialization
	void Start () {
        

	}
	
    void Damage(int d)
    {
        enemyHealth -= d;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (first) {
            first = false;
            generateEnemy();
        }
        if (enemyHealth <= 0)
            killEnemy();
	}


    void killEnemy()
    {
        if (splitter)
        {
            int[] basicEnemy = new int[] {0,0,0,0};
            GameObject spliti = Instantiate(split, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            spliti.GetComponent<EnemyScript>().enemySpecs = basicEnemy;
            spliti = Instantiate(split, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            spliti.GetComponent<EnemyScript>().enemySpecs = basicEnemy;
        }
        Destroy(transform.gameObject);
    }
}


