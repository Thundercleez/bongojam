using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatIconSlider : MonoBehaviour {

    public BeatDisplay beatDisplay;
    public Vector3 tarPos;
    public float slideTime;
    float startTime;
    Vector3 startPos;
    RectTransform rect;

    // Use this for initialization
    void Start () {
        startTime = Time.time;
        rect = gameObject.GetComponent<RectTransform>();
        startPos = rect.anchoredPosition;
    }
	
	// Update is called once per frame
	void Update () {
        float perc = (Time.time - startTime) / slideTime;
        rect.anchoredPosition = Vector3.Lerp(startPos, tarPos, perc);
	}

    private void OnDestroy()
    {
        beatDisplay.RemoveBeatSlider();
    }
}
