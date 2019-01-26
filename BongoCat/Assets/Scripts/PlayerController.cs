using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float inputBuffer = .016f * 3;

    delegate void action_t();
    List<action_t> actions;

    enum ActionsEnum { JUMP_LEFT, JUMP_RIGHT, DOUBLE_JUMP };

    class InputEntry
    {
        public float inputTime;
        public ActionsEnum inputAction;
        public bool processed;
    }

    List<InputEntry> inputEntries;

	// Use this for initialization
	void Start () {
        inputEntries = new List<InputEntry>();

        actions = new List<action_t>();
        actions.Add(JumpLeft);
        actions.Add(JumpRight);
        actions.Add(DoubleJump);
    }
	
	// Update is called once per frame
	void Update () {
        ReadInputs();
        ProcessInputs();
	}

    void ProcessInputs()
    {
        for(int i = 0; i < inputEntries.Count; i++)
        {
            if(!inputEntries[i].processed)
            {
                inputEntries[i].processed = true;
                actions[(int)inputEntries[i].inputAction]();
            }
        }
    }

    void ReadInputs()
    {
        for(int i = inputEntries.Count - 1; i >= 0; i--)
        {
            if(Time.time - inputEntries[i].inputTime >= inputBuffer)
            {
                inputEntries.RemoveAt(i);
            }
        }

        for(int i = 0; i < Globals.Instance.keyMappings.Count; i++)
        {
            if(Input.GetKeyDown(Globals.Instance.keyMappings[i]))
            {
                InputEntry ie = new InputEntry();
                ie.inputTime = Time.time;
                if(i == (int)Globals.InputIndexMappingEnum.LEFT_INPUT_INDEX)
                {
                    ie.inputAction = ActionsEnum.JUMP_LEFT;
                }else
                {
                    ie.inputAction = ActionsEnum.JUMP_RIGHT;
                }

                if(inputEntries.Count == 1)
                {
                    ie.inputAction = ActionsEnum.DOUBLE_JUMP;
                }
                inputEntries.Add(ie);
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
