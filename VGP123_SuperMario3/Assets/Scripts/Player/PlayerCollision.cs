using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    AudioSource deathAudioSource;
    public AudioClip deathSFX;
    PlayerMovement pm;
    SpriteRenderer sr;

    private void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            DeathSound();
            Destroy(Col.gameObject);
            StartCoroutine(Death());
        }
        if (Col.gameObject.tag == "EnemyWalker")
        {
            DeathSound();
            StartCoroutine(Death());
        }
        if (Col.gameObject.tag == "EnemyHead")
        {
            if (!pm.isGrounded)
            {
                Destroy(transform.parent.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D Col)
    {
        if (Col.gameObject.tag == "DeathCol")
        {
            DeathSound();
            StartCoroutine(Death());
        }
    }

    void DeathSound()
    {
        if (!deathAudioSource)
        {
            deathAudioSource = gameObject.AddComponent<AudioSource>();
            deathAudioSource.clip = deathSFX;
            deathAudioSource.loop = false;
            deathAudioSource.Play();
        }
        else
        {
            deathAudioSource.Play();
        }
    }

    IEnumerator Death()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        yield return new WaitForSeconds(1);
        GameManager.instance.lives--;
        Debug.Log("Lives: " + GameManager.instance.lives);
        GameManager.instance.CM.SetLivesText();
    }

    // Start is called before the first frame update
    void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
