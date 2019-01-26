using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    float moveSpeed;

    Rigidbody rb;
    Vector3 curDir;
    bool jumping;
    Vector3 tarPos;

    Animator animController;
    bool jumpEnd;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animController = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		if(jumping)
        {
            Vector3 tarDir = tarPos - gameObject.transform.position;
            tarDir.Normalize(); 
            curDir = Vector3.RotateTowards(curDir, tarDir, rotateSpeed * Time.deltaTime, 0);
            
            float distDelta = Vector3.Distance(gameObject.transform.position, tarPos);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + curDir * distDelta, moveSpeed * Time.deltaTime);
            float distToTar = Vector3.Distance(gameObject.transform.position, tarPos);
            if (distToTar < .1f)
            {
                gameObject.transform.position = tarPos;
                jumping = false;
                rb.isKinematic = false;
            }else if(distToTar < 2.5f)
            {
                if (!jumpEnd)
                {
                    animController.SetTrigger("JumpEnd");
                    jumpEnd = true;
                }
            }
        }
	}

    public void Jump (Vector3 jumpForce, Vector3 target)
    {
        if (!jumping)
        {
            tarPos = target;
            jumping = true;
            //rb.AddForce(jumpForce, ForceMode.Impulse);
            rb.isKinematic = true;
            curDir = Vector3.up;
            animController.SetTrigger("JumpStart");
            jumpEnd = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(gameObject.transform.position, gameObject.transform.position + curDir * 10);
    }
}
