using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMover : MonoBehaviour {

    public float speed = 3f;
    public int damageAmount = 10;
    public string direction;
    public AudioClip attackSFX;

    new Rigidbody2D rigidbody;
    new AudioSource audio;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        if (rigidbody == null) // if Rigidbody is missing
            Debug.LogError("Rigidbody2D component missing from this gameobject");

        audio = GetComponent<AudioSource>();
        if (audio == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            audio = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update ()
    {
		if (direction == "Right" || direction == "right")
        {
            rigidbody.AddForce(Vector2.right * speed);
        }
        else if (direction == "Left" || direction == "left")
        {
            rigidbody.AddForce(Vector2.left * speed);
        }
        else if (direction == "Up" || direction == "up")
        {
            rigidbody.AddForce(Vector2.up * speed);
        }
        else if (direction == "Down" || direction == "down")
        {
            rigidbody.AddForce(Vector2.down * speed);
        }
        else
        {
            Debug.LogError("Set arrow direction to right, left, up or down.");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            {
                CharacterController2D player = other.gameObject.GetComponent<CharacterController2D>();
                if (player.playerCanMove)
                {
                    playSound(attackSFX);
                    rigidbody.velocity = new Vector2(0, 0);
                    player.ApplyDamage(damageAmount);
                }
            }
        }
    }

    void playSound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
