using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YarnBall : MonoBehaviour {

    [SerializeField]
    GameObject yarnballEffectFab;

    int playerLayer;

	// Use this for initialization
	void Start () {
        playerLayer = LayerMask.NameToLayer("Player");
        Physics.IgnoreLayerCollision(playerLayer, LayerMask.NameToLayer("Yarn"));
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == playerLayer)
        {
            Globals.Instance.score++;
            Destroy(gameObject.transform.parent.gameObject);
            GameObject yarnBall = Instantiate(yarnballEffectFab, gameObject.transform.position, Quaternion.identity);
            yarnBall.AddComponent<TimedObject>().lifeTime = 1.5f;
        }
    }
}
