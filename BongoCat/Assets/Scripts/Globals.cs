using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : Singleton<Globals> {

    public GameObject playerObj;
    public Camera mainCam;
    public List<KeyCode> keyMappings;
    public int score;

    public enum InputIndexMappingEnum { LEFT_INPUT_INDEX, RIGHT_INPUT_INDEX };

	// Use this for initialization
	void Awake () {
        mainCam = GameObject.Find("Camera").GetComponent<Camera>();
        keyMappings = new List<KeyCode>();
        keyMappings.Add(KeyCode.A);
        keyMappings.Add(KeyCode.L);

        playerObj = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(mainCam == null)
        {
            Awake();
        }
    }
}
