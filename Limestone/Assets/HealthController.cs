using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour {

    public int livesRemain = 5;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount == 0)
            // end game
            print("You lose");
	}

    void loseHeart()
    {
        Destroy(transform.GetChild(livesRemain - 1));
        livesRemain--;
    }
}
