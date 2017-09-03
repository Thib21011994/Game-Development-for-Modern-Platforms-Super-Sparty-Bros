using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour {

    public int damageAmount = 10;
    public AudioClip attackSFX;

    Rigidbody2D _rigidbody;
    AudioSource _audio;
    
    // Use this for initialization
    void Awake ()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        if (_rigidbody == null) // if Rigidbody is missing
            Debug.LogError("Rigidbody2D component missing from this gameobject");

        _audio = GetComponent<AudioSource>();
        if (_audio == null)
        { // if AudioSource is missing
            Debug.LogWarning("AudioSource component missing from this gameobject. Adding one.");
            // let's just add the AudioSource component dynamically
            _audio = gameObject.AddComponent<AudioSource>();
        }
    }
	
	// Attack player
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            CharacterController2D player = collision.gameObject.GetComponent<CharacterController2D>();
            if (player.playerCanMove)
            {
                playSound(attackSFX);
                _rigidbody.velocity = new Vector2(0, 0);
                player.ApplyDamage(damageAmount);
            }
        }
    }

    void playSound(AudioClip clip)
    {
        _audio.PlayOneShot(clip);
    }

}
