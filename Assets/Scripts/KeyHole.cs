using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyHole : MonoBehaviour {

    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        CharacterController2D player = other.GetComponent<CharacterController2D>();
        if (other.tag == "Player" && player.holdsKey)
        {
            if (explosion)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            player._hasWin = true;
            player.Victory();
            Destroy(gameObject);
        }
    }
}
