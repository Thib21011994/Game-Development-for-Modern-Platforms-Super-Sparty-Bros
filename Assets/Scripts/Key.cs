using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour {

    public Vector3 playerOffset = new Vector3(0, 1, 0);
        
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            CharacterController2D player = other.GetComponent<CharacterController2D>();
            if (!player.holdsKey)
            {
                transform.parent = other.transform;
                transform.localPosition = playerOffset;
                player.holdsKey = true;
                if (player._hasWin)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
