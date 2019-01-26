using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : Singleton<Globals> {

    public GameObject playerObj;
    public Camera mainCam;
    public List<List<KeyCode>> keyMappings;
    public int score;

    public enum InputIndexMappingEnum { LEFT_INPUT_INDEX, RIGHT_INPUT_INDEX };

	// Use this for initialization
	void Awake () {
        mainCam = GameObject.Find("Camera").GetComponent<Camera>(); //camera name needs to changed in some cases oc
        keyMappings = new List<List<KeyCode>>();
        keyMappings.Add(new List<KeyCode>());
        keyMappings.Add(new List<KeyCode>());

        keyMappings[0].Add(KeyCode.A);
        keyMappings[0].Add(KeyCode.L);

        keyMappings[1].Add(KeyCode.Joystick1Button0);
        keyMappings[1].Add(KeyCode.Joystick1Button3);

        playerObj = GameObject.FindGameObjectWithTag("Player"); //player must be tagged player oc
    }

    private void Update()
    {
        if(mainCam == null)
        {
            Awake();
        }
    }
}
