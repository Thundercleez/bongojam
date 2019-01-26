using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour {

    public GameObject waterEffectFab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag.Equals("Player"))
        {
            GameObject splash = Instantiate(waterEffectFab);
            splash.transform.position = gameObject.transform.GetChild(0).position;
            splash.AddComponent<TimedObject>().lifeTime = 2.5f;
            GetComponent<Rigidbody>().AddForceAtPosition(new Vector3(300, 0, 0), gameObject.transform.position + Vector3.up * 3f);
            collision.collider.gameObject.GetComponent<PlayerJump>().BucketJump(gameObject.transform.position + Vector3.back * 10 + Vector3.down * 10);
            collision.collider.gameObject.transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
    }
}
