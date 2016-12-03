using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttack : MonoBehaviour {

	public float towerSpeed;
	public float towerRange;
	public int towerDamage;
	public int towerType;
    public int towerPrice;
	public GameObject bullet;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("attack", 0f, towerSpeed);
        //remove player money based on price
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	// called to attack an enemy or enemies in range
	void attack() {
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll (transform.position, towerRange, 1 << LayerMask.NameToLayer ("Enemies"));
		if (hitColliders.Length != 0) {
			if (towerType == 0) { // hits one enemy at a time
				hitColliders [0].SendMessage ("Damage", towerDamage);
				shoot(hitColliders[0].transform);
			} else if (towerType == 1) { // hits all enemies in range
				for (var i = 0; i < hitColliders.Length; i++) {
					hitColliders [i].SendMessage ("Damage", towerDamage);
					shoot(hitColliders[i].transform);
				}
			}
		}
	}

	void shoot(Transform enemy) {
        Vector2 direction = new Vector2(enemy.position.x - transform.position.x, enemy.position.y - transform.position.y);
        float rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        GameObject bulletInstance = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, -1f), Quaternion.Euler(0,0,rotation + 90));
        bulletInstance.GetComponent<BulletController>().enemyPosit = enemy.position;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(transform);
            //give player money back
        }
    }
}
