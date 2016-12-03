using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutController : MonoBehaviour {

    public float maxLeft = 5.95f;
    public float maxRight = 9.45f;
    //public bool mouseOff = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x != maxRight && (Input.mousePosition.y > 320 || Input.mousePosition.y < 12 || Input.mousePosition.x < 436 || Input.mousePosition.x > 580))
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
    }

    void OnMouseOver() {
        //mouseOff = false;
        if (transform.position.x != maxLeft)
            transform.position = new Vector3(transform.position.x - 0.5f,transform.position.y, transform.position.z);
    }
}
