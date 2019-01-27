using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

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
                if (InputManager.Instance.inputEntries[i].inputAction == InputManager.ActionsEnum.JUMP_LEFT)
                {
                    Application.Quit();
                }
                else if (InputManager.Instance.inputEntries[i].inputAction == InputManager.ActionsEnum.JUMP_RIGHT)
                {
                    Application.LoadLevel("StartMenu");
                }
            }
        }
    }
}
