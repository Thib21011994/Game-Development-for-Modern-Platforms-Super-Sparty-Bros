using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroyer : MonoBehaviour {

    public float lifeSpan = 10f;

    float waitTime = 0f;

    void Update ()
    {
        waitTime += Time.deltaTime;
        if (waitTime > lifeSpan)
        {
            Destroy(gameObject);
        }
    }
}
