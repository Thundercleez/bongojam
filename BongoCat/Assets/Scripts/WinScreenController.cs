﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    public static int curLevel = 1;
    delegate void action_t();
    List<action_t> actions;

    // Use this for initialization
    void Start()
    {
        actions = new List<action_t>();
        actions.Add(LoadNextLevel);
        actions.Add(LoadNextLevel);

        InputManager foo = InputManager.Instance;
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
                actions[(int)InputManager.Instance.inputEntries[i].inputAction]();
            }
        }
    }

    void LoadNextLevel()
    {
        curLevel++;
        if (curLevel <= 4)
        {
            Application.LoadLevel("Level" + curLevel);
        }else
        {
            Application.LoadLevel("Credits");
        }
    }
}
