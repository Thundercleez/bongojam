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
    bool doJump;
    bool jumping;
    bool doubleJumping;
    Vector3 tarPos;

    Animator animController;
    bool jumpEnd;
    bool jumpCommitted;

    Vector3 startPos;

    BeatDisplay beatDisplay;
    ParticleSystem inTimeEmitter;

    //audio 
    // [Space(10)] //has to have thing underneath
    //[SerializeField]
    AudioSource JumpNoise;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        animController = gameObject.GetComponent<Animator>();
        beatDisplay = GameObject.FindObjectOfType<BeatDisplay>();
        //inTimeEmitter = beatDisplay.GetComponentInChildren<ParticleSystem>();

        JumpNoise = GetComponent<AudioSource>();
        startPos = Vector3.zero;
    }
	
	// Update is called once per frame
	void Update () {
		if(doJump)
        {
            Vector3 tarDir = tarPos - gameObject.transform.position;
            tarDir.Normalize(); 
            curDir = Vector3.RotateTowards(curDir, tarDir, rotateSpeed * Time.deltaTime, 0);
            
            float distDelta = Vector3.Distance(gameObject.transform.position, tarPos);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, gameObject.transform.position + curDir * distDelta, moveSpeed * Time.deltaTime);
            float distToTar = Vector3.Distance(gameObject.transform.position, tarPos);
            if (distToTar < .3f)
            {
                gameObject.transform.position = tarPos;
                rb.isKinematic = false;
                doJump = false;
            }
            else if(distToTar < 2.5f)
            {
                if (!jumpEnd)
                {
                    animController.SetTrigger("JumpEnd");
                    jumpEnd = true;
                }
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag.Equals("Platform"))
        {
            jumping = false;
            doubleJumping = false;
            startPos = Vector3.zero;
            jumpCommitted = false;
            Debug.Log(Time.time + " landed");
            animController.SetTrigger("ResetAnim");
            animController.ResetTrigger("JumpStart");
            animController.ResetTrigger("JumpEnd");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.gameObject.tag.Equals("Platform"))
        {
            jumping = false;
            doubleJumping = false;
            startPos = Vector3.zero;
            jumpCommitted = false;
        }
    }

    public void SetJumpCommitted()
    {
        jumpCommitted = true;
    }

    public void Jump (Vector3 target, bool overwrite)
    {
        if(jumpCommitted)
        {
            Debug.Log(Time.time + " jump is committed");
            return;
        }else if (!jumping || (!doubleJumping && overwrite))
        {
            tarPos = target;
            rb.isKinematic = true;
            curDir = Vector3.up;
            if (!jumping)
            {
                animController.SetTrigger("JumpStart");

                //should play audio on jump
                JumpNoise.Play();
            }
            jumpEnd = false;
            if (!overwrite || startPos.sqrMagnitude == Vector3.zero.sqrMagnitude)
            {
                startPos = gameObject.transform.position;
                Debug.Log(Time.time + " reset start pos");
            }
            else
            {
                gameObject.transform.position = startPos;
                startPos = gameObject.transform.position;
                Debug.Log(Time.time + " reset player");
            }
            if (!overwrite)
            {
                if (beatDisplay.IsInTime())
                {
                    //DisplayBeatEffect(true);
                    Globals.Instance.score += 5;
                }
                /*else
                {
                    DisplayBeatEffect(false);
                }*/
            }
            doJump = true;
            jumping = true;
            doubleJumping = overwrite;
        }
    }

    public void BucketJump(Vector3 target)
    {
        tarPos = target;
        rb.isKinematic = true;
        curDir = Vector3.up;
        if (!jumping)
        {
            animController.SetTrigger("JumpStart");
        }
        jumpEnd = false;
        doJump = true;
        jumping = true;
    }
    
    //WR: Attempting Display Beat Effect
    /*void DisplayBeatEffect(bool inTime)
    {
        if (inTime)
        {
            inTimeEmitter.Play();
        }
        else
        {

        }
    }*/
}
