using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBody : MonoBehaviour {

    public float gravityModifier = 0.1f;
    public float originalGravity = 2f;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D character = collision.GetComponent<CharacterController2D>();
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            character.playerIsUnderWater = true;
            rigidbody.gravityScale = gravityModifier;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D character = collision.GetComponent<CharacterController2D>();
            Rigidbody2D rigidbody = collision.GetComponent<Rigidbody2D>();
            character.playerIsUnderWater = false;
            rigidbody.gravityScale = originalGravity;
        }
    }
}
