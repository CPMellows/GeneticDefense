using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutSpriteMovement : MonoBehaviour {

    public GameObject towerSprite;
    private Vector3 relation;

	// Use this for initialization
	void Start () {
        relation = new Vector3(transform.parent.position.x - transform.position.x,
                                transform.parent.position.y - transform.position.y,
                                transform.parent.position.z - transform.position.z);
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = transform.parent.position - relation;
	}

    void OnMouseDown()
    {
        Instantiate(towerSprite);
    }
}
