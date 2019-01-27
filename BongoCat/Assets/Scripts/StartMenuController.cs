using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
    }

    void ProcessInputs()
    {
        for (int i = 0; i < InputManager.Instance.inputEntries.Count; i++)
        {
            if (!InputManager.Instance.inputEntries[i].processed)
            {
                InputManager.Instance.inputEntries[i].processed = true;
                Application.LoadLevel("Level1");
            }
        }
    }
}
