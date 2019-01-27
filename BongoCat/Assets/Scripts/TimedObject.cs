using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour {

    public float lifeTime;
    float timer;

    public float GetRemTime()
    {
        return lifeTime - (Time.time - timer);
    }

	// Use this for initialization
	void Start () {
        timer = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time - timer >= lifeTime)
        {
            Destroy(gameObject);
        }
	}
}
