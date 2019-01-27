using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    delegate void action_t();
    List<action_t> actions;

    private PlayerJump jumpScript;

    // Use this for initialization
    void Start () {

        actions = new List<action_t>();
        actions.Add(JumpLeft);
        actions.Add(JumpRight);
        actions.Add(DoubleJump);
        actions.Add(CommitJump);

        //Get the the attached gameobject's PlayerJump script and store it in the jumpScript variable.

        jumpScript = this.GetComponent<PlayerJump>();

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

    void CommitJump()
    {
        Debug.Log(Time.time + " commit jump");
        jumpScript.SetJumpCommitted();
    }

    void JumpLeft()
    {
        //Create a Vector3 that uses the horizontal and vertical jump force parameters.
        //Call the jumpScript's Jump function and pass in the applicable JumpForce Vector3.
        Vector3 tarPos = gameObject.transform.position + new Vector3(-20, 10, 0); 
        jumpScript.Jump(tarPos, false);
        Debug.Log(Time.time + " JumpLeft"); //should be right
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.left); 
    }

    void JumpRight()
    {
        //Create a Vector3 that uses the negative horizonal and regular vertical jump force parameters.
        //Call the jumpScript's Jump function and pass in the applicable JumpForce Vector3.
        Vector3 tarPos = gameObject.transform.position + new Vector3(20, 10, 0);
        jumpScript.Jump(tarPos, false);
        Debug.Log(Time.time + " JumpRight"); //should be left
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.right); 
    }

    void DoubleJump()
    {
        Vector3 tarPos = gameObject.transform.position + new Vector3(0, 10, 0);
        jumpScript.Jump(tarPos, true);
        Debug.Log(Time.time + " DoubleJump");
    }
}
