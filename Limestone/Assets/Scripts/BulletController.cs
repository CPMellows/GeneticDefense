using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	public int velocity = 1;
	public Vector2 enemyPosit;
    public int speed = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        // transform.position = Vector2.MoveTowards
        //           (new Vector2(transform.position.x, transform.position.y), enemyPosit, speed * Time.deltaTime);
        Destroy(transform.gameObject);
    }

    void setPoisition(Vector2 position) {
        enemyPosit = position;
    }


}
