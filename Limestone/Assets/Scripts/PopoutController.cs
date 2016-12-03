using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoutController : MonoBehaviour {

    public float maxLeft = 5.95f;
    public float maxRight = 9.45f;
    private bool mouseOff = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x != maxRight && mouseOff)
            transform.position = new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z);
    }

    void OnMouseOver() {
        mouseOff = false;
        if (transform.position.x != maxLeft)
            transform.position = new Vector3(transform.position.x - 0.5f,transform.position.y, transform.position.z);
    }

    void OnMouseExit() {
        mouseOff = true;
    }
}
