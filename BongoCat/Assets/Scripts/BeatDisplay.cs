using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatDisplay : MonoBehaviour {

    [SerializeField]
    float bpm;

    float timer;
    float timeout = .016f * 5;
    [SerializeField]
    Sprite beatIconSprite;

    Queue<GameObject> beatSliders;

	// Use this for initialization
	void Start () {
        beatSliders = new Queue<GameObject>();
        timer = Time.time - timeout;
    }

    public void RemoveBeatSlider()
    {
        beatSliders.Dequeue();
    }

    public bool IsInTime()
    {
        if (beatSliders.Count > 0)
        {
            return (beatSliders.Peek().GetComponent<TimedObject>().GetRemTime() < .016f * 10);
        }else
        {
            return false;
        }
    }

    int count = 1;
	// Update is called once per frame
	void Update () {
        float beatRate = (60f / bpm);
        float dt = Time.timeSinceLevelLoad - beatRate;
        if (Mathf.Abs(dt) >= beatRate * .75f)
        {
            while (dt > 0)
            {
                dt -= beatRate;
            }

            if (Time.time - timer >= beatRate * .75f &&
                Mathf.Abs(dt) <= .016f * 2)
            {
                timer = Time.time;
                GameObject leftIcon = Instantiate(gameObject) as GameObject;
                leftIcon.GetComponent<Image>().sprite = beatIconSprite;
                leftIcon.transform.SetParent(gameObject.transform.parent);
                leftIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(-Screen.width * .5f, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                leftIcon.AddComponent<TimedObject>().lifeTime = beatRate + 2 + .016f * 5;
                leftIcon.name = "Left Icon " + count;
                DestroyImmediate(leftIcon.GetComponent<BeatDisplay>());
                BeatIconSlider bis = leftIcon.AddComponent<BeatIconSlider>();
                bis.slideTime = beatRate + 2;
                bis.tarPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
                bis.beatDisplay = this;

                beatSliders.Enqueue(leftIcon);

                GameObject rightIcon = Instantiate(gameObject) as GameObject;
                rightIcon.GetComponent<Image>().sprite = beatIconSprite;
                rightIcon.transform.SetParent(gameObject.transform.parent);
                rightIcon.GetComponent<RectTransform>().anchoredPosition = new Vector2(Screen.width * .5f, gameObject.GetComponent<RectTransform>().anchoredPosition.y);
                rightIcon.AddComponent<TimedObject>().lifeTime = beatRate + 2 + .016f * 5;
                rightIcon.name = "Right Icon " + count++;
                DestroyImmediate(rightIcon.GetComponent<BeatDisplay>());
                bis = rightIcon.AddComponent<BeatIconSlider>();
                bis.slideTime = beatRate + 2;
                bis.tarPos = gameObject.GetComponent<RectTransform>().anchoredPosition;
                bis.beatDisplay = this;
                beatSliders.Enqueue(rightIcon);
            }
        }
    }
}
