using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimTest : MonoBehaviour {

    Animator animController;

    // Use this for initialization
    void Start () {
        animController = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        KeyCode pressed = InputManager.WhichKeyDown();
        if(pressed != KeyCode.None)
        {
            Debug.Log("Pressed: " + pressed);
        }
    }
}
