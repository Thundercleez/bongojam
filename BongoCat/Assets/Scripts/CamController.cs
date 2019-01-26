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
    GameObject loseText;

    float curSpeed;

	// Use this for initialization
	void Start () {
        curSpeed = startSpeed;
    }
	
	// Update is called once per frame
	void Update () {
        curSpeed += Time.deltaTime * accelRate;
        float camSpeed = Mathf.Clamp(Mathf.Pow(curSpeed, 2) + Mathf.Log(curSpeed) + 2, startSpeed, maxSpeed);

        gameObject.transform.position += Vector3.up * camSpeed;

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
