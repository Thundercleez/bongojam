using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour 
{

    public GameObject leftTilePrefab;

    public GameObject currentTile;

	void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnTile()
    {
        currentTile = (GameObject)Instantiate(leftTilePrefab, currentTile.transform.GetChild(0).transform.GetChild(0).position, Quaternion.identity);
            
    }
}
