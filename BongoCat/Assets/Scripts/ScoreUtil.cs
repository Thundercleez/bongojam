using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUtil : MonoBehaviour {

    public TextMeshProUGUI scoreValue;

    int lastScore;

	// Use this for initialization
	void Start () {
        lastScore = Globals.Instance.score;
    }
	
	// Update is called once per frame
	void Update () {
		if(lastScore != Globals.Instance.score)
        {
            lastScore = Globals.Instance.score;
            scoreValue.text = lastScore + "";
        }
	}
}
