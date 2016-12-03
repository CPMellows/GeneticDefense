using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawn: MonoBehaviour {

	[SerializeField]
	private GameObject tile;

	// Use this for initialization
	void Start () 
	{
		CreateLevel();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	//Used for creating levels in the game
	private void CreateLevel() 
	{
        float tileX = (float)tile.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileY = (float)tile.GetComponent<SpriteRenderer>().bounds.size.y;
        for (int y = 0; y < 10; y++)
		{
			for (int x = 0; x < 20; x++)
			{
				GameObject newTile = Instantiate (tile);
                newTile.transform.parent = transform;
				newTile.transform.position = new Vector3(tileX * x - 7.5f, tileY * y - 4.5f);
 			}
		}
	}
}
