using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    public float vJumpForce = 10f;
    [SerializeField]
    public float hJumpForce = 5f;

    delegate void action_t();
    List<action_t> actions;

    private PlayerJump jumpScript;

    // Use this for initialization
    void Start () {

        actions = new List<action_t>();
        actions.Add(JumpLeft);
        actions.Add(JumpRight);
        actions.Add(DoubleJump);

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

    void JumpLeft()
    {
        //Create a Vector3 that uses the horizontal and vertical jump force parameters.
        Vector3 lJumpForce = new Vector3(hJumpForce, vJumpForce);
        //Call the jumpScript's Jump function and pass in the applicable JumpForce Vector3.
        Vector3 tarPos = gameObject.transform.position + new Vector3(-20, 10, 0);
        jumpScript.Jump(lJumpForce, tarPos);
        Debug.Log(Time.time + " JumpLeft");
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.left);
    }

    void JumpRight()
    {
        //Create a Vector3 that uses the negative horizonal and regular vertical jump force parameters.
        Vector3 rJumpForce = new Vector3(-hJumpForce, vJumpForce);
        //Call the jumpScript's Jump function and pass in the applicable JumpForce Vector3.
        Vector3 tarPos = gameObject.transform.position + new Vector3(20, 10, 0);
        jumpScript.Jump(rJumpForce, tarPos);
        Debug.Log(Time.time + " JumpRight");
        gameObject.transform.rotation = Quaternion.LookRotation(Vector3.right);
    }

    void DoubleJump()
    {
        Debug.Log(Time.time + " DoubleJump");
    }
}
