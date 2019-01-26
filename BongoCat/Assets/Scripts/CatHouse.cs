using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHouse : MonoBehaviour {

    public GameObject winText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            Globals.Instance.playerObj.GetComponent<PlayerController>().enabled = false;
            Globals.Instance.mainCam.gameObject.GetComponent<CamController>().enabled = false;
            winText.SetActive(true);
        }
    }
}
