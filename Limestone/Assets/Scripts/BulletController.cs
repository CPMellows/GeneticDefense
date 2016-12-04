using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public int velocity = 1;
	public Vector2 enemyPosit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Vector3.MoveTowards
                   (new Vector3(transform.position.x, transform.position.y, -1f), enemyPosit, 20 * Time.deltaTime);
        if (Vector3.Distance(transform.position, enemyPosit) < 1f)
            Destroy(transform.gameObject);
    }
}
