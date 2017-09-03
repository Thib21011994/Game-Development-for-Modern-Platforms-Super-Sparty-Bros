using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeModifier : MonoBehaviour {

    public Vector3 multiplier = new Vector3(10, 10, 0);
    bool isGiant = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 positionModifier = new Vector3(0, multiplier.y/2, 0);
        if (other.tag == "Enemy" && isGiant == false)
        {
            other.gameObject.transform.localPosition += positionModifier;
            other.gameObject.transform.localScale += multiplier;
            isGiant = true;
            Destroy(gameObject);
        }

        else if (other.tag == "Enemy" && isGiant == true)
        {
            other.gameObject.transform.localPosition -= positionModifier;
            other.gameObject.transform.localScale -= multiplier;
            isGiant = false;
            Destroy(gameObject);
        }
    }
}
