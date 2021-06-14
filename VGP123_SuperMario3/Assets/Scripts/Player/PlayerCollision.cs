using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    AudioSource deathAudioSource;
    public AudioClip deathSFX;

    private void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Projectile" || Col.gameObject.tag == "EnemyWalker")
        {
            DeathSound();
            Destroy(Col.gameObject);
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
        yield return new WaitForSeconds(1);
        GameManager.instance.lives--;
        Debug.Log("Lives: " + GameManager.instance.lives);
        GameManager.instance.CM.SetLivesText();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
