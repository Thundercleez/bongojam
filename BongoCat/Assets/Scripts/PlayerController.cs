﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    delegate void action_t();
    List<action_t> actions;

	// Use this for initialization
	void Start () {

        actions = new List<action_t>();
        actions.Add(JumpLeft);
        actions.Add(JumpRight);
        actions.Add(DoubleJump);

        InputManager foo = InputManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
        ProcessInputs();
	}

    void ProcessInputs()
    {
        for(int i = 0; i < InputManager.Instance.inputEntries.Count; i++)
        {
            if(!InputManager.Instance.inputEntries[i].processed)
            {
                InputManager.Instance.inputEntries[i].processed = true;
                actions[(int)InputManager.Instance.inputEntries[i].inputAction]();
            }
        }
    }

    void JumpLeft()
    {
        Debug.Log(Time.time + " JumpLeft");
    }

    void JumpRight()
    {
        Debug.Log(Time.time + " JumpRight");
    }

    void DoubleJump()
    {
        Debug.Log(Time.time + " DoubleJump");
    }
}
