using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private Rigidbody2D Rigid;

    AudioSource deathAudioSource;
    public AudioClip deathSFX;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0)
        {
            lifetime = 2.0f;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "coin" || col.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Fireball")
        {
            DeathSound();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
    void DeathSound()
    {
        if (!deathAudioSource)
        {
            deathAudioSource = gameObject.AddComponent<AudioSource>();
           // deathAudioSource.volume = 0.2f;
            deathAudioSource.clip = deathSFX;
            deathAudioSource.loop = false;
            deathAudioSource.Play();
        }
        else
        {
            deathAudioSource.Play();
        }
    }
}
