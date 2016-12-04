using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public int destination = 0;
    public int speed = 2;
    public Vector3[] points;
	// Use this for initialization
	void Start () {
        buildArray();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (destination == 10)
            Destroy(transform.gameObject);
        transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -2f), points[destination], speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, points[destination]) < 0.3f)
            destination++;
        //print(destination);
    }

    void buildArray()
    {
        points = new Vector3[10];
        points[0] = new Vector3(-3.78f, 2.06f, -2f);
        points[1] = new Vector3(-3.78f, 3.12f, -2f);
        points[2] = new Vector3(-0.43f, 3.12f, -2f);
        points[3] = new Vector3(-0.43f, -0.07f, -2f);
        points[4] = new Vector3(-5.37f, -0.07f, -2f);
        points[5] = new Vector3(-5.37f, -3.19f, -2f);
        points[6] = new Vector3(2.08f, -3.19f, -2f);
        points[7] = new Vector3(2.08f, 3.05f, -2f);
        points[8] = new Vector3(5.43f, 3.05f, -2f);
        points[9] = new Vector3(5.43f, -3.95f, -2f);
    }
}
