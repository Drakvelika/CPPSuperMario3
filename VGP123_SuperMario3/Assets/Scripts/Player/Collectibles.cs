using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D), typeof(Animator))]
public class Collectibles : MonoBehaviour
{
    Animator anim;

    public enum CollectibleType
    {
        POWERUP,
        COLLECTIBLE,
        LIVES
    }

    public CollectibleType currentCollectible;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //("coin 1");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            switch (currentCollectible)
            {
                case CollectibleType.COLLECTIBLE:
                    PlayerMovement pmScript = col.gameObject.GetComponent<PlayerMovement>();
                    pmScript.score++;
                    Debug.Log(pmScript.score);
                    break;
                case CollectibleType.LIVES:
                    pmScript = col.gameObject.GetComponent<PlayerMovement>();
                    pmScript.lives++;
                    Debug.Log(pmScript.lives);
                    break;
                case CollectibleType.POWERUP:
                    col.gameObject.GetComponent<PlayerMovement>().StartJChange();
                    break;
            }
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "coin")
        {
            Destroy(col.gameObject);
        }
    }
}
