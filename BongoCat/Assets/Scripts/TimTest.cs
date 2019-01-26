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
		if(Input.GetKeyDown(KeyCode.Q))
        {
            animController.SetTrigger("JumpStart");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            animController.SetTrigger("JumpEnd");
        }

        KeyCode pressed = InputManager.WhichKeyDown();
        if(pressed != KeyCode.None)
        {
            Debug.Log("Pressed: " + pressed);
        }
    }
}
