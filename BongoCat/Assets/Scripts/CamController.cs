using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour {

    [SerializeField]
    float startSpeed;
    [SerializeField]
    float accelRate;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float loseThreshold;
    [SerializeField]
    float followSpeed;

    [SerializeField]
    GameObject loseText;

    [SerializeField]
    float rainbowThreshold;
    bool rainbowOn;

    float curSpeed;
    bool following;

	// Use this for initialization
	void Start () {
        curSpeed = startSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        curSpeed += Time.deltaTime * accelRate;
        float camSpeed = Mathf.Clamp(Mathf.Pow(curSpeed, 2) + Mathf.Log(curSpeed) + 2, startSpeed, maxSpeed);

        if(!rainbowOn &&
            camSpeed > rainbowThreshold)
        {
            rainbowOn = true;
            Globals.Instance.playerObj.transform.Find("RainbowTrail").gameObject.SetActive(true);
        }

        gameObject.transform.position += Vector3.up * camSpeed;
        Vector3 screenPos = Globals.Instance.mainCam.WorldToScreenPoint(Globals.Instance.playerObj.transform.position);
        float xOffset = Screen.width * .5f - screenPos.x;
        if(following ||
            Mathf.Abs(xOffset) > Screen.width * .13f)
        {
            following = true;
            Vector3 tarDir = Globals.Instance.playerObj.transform.position - gameObject.transform.position;
            tarDir.Normalize();
            tarDir.y = 0;
            tarDir.z = 0;
            gameObject.transform.position += tarDir * followSpeed * Time.deltaTime;
            float xDiff = Mathf.Abs(gameObject.transform.position.x - Globals.Instance.playerObj.transform.position.x);
            if(xDiff < .1f)
            {
                following = false;
            }
        }

        CheckLose();
    }

    void CheckLose()
    {
        Vector3 screenPos = Globals.Instance.mainCam.WorldToScreenPoint(Globals.Instance.playerObj.transform.position);
        if(screenPos.y < loseThreshold)
        {
            enabled = false;
            loseText.SetActive(true);
            Globals.Instance.playerObj.SetActive(false);
        }
    }
}
