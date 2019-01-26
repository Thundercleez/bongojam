using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScreenController : MonoBehaviour {

    delegate void action_t();
    List<action_t> actions;

    // Use this for initialization
    void Start () {
        actions = new List<action_t>();
        actions.Add(SelectYes);
        actions.Add(SelectNo);

        InputManager foo = InputManager.Instance;
    }
	
	// Update is called once per frame
	void Update () {
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

    void SelectYes()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void SelectNo()
    {
        Application.Quit();
    }
}
