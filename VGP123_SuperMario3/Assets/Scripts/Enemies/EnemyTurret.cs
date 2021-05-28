using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    public Transform player;
    public Transform projectileSpawnPoint;
    public Projectile projectilePrefab;
    public float projectileForce;
    GameObject projectile;

    public bool isFacingRight;

    public float projectileFireRate;
    public float turretFireRange;
    float timeSinceLastShot = 0.0f;

    public int health;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (!projectileSpawnPoint)
        {
            Debug.Log("No projectileSpawnPoint found.");
        }
        if (!projectilePrefab)
        {
            Debug.Log("No projectilePrefab found.");
        }
        if (projectileForce == 0)
        {
            projectileForce = 3.0f;
            Debug.Log("projectileForce was not set. Defaulting to " + projectileForce);
        }

        if (projectileFireRate == 0)
        {
            projectileFireRate = 2.0f;
            Debug.Log("projectileFireRate was not set. Defaulting to " + projectileFireRate);
        }

        if (health == 0)
        {
            health = 5;
            Debug.Log("health was not set. Deafulting to " + health);
        }
    }

    // Update is called once per frame
    void Update()
    {
      //  if (player)
      /*  {
            if (player.transform.position.x < transform.position.x)
            {
                sr.flipX = true;
            }
            else
            {
                sr.flipX = false;
            }
        }*/
        if (transform.position.x < player.position.x && !isFacingRight)
        {
            flip();
        }
        else if (transform.position.x > player.position.x && isFacingRight)
        {
            flip();
        }

        if (Time.time >= timeSinceLastShot + projectileFireRate)
        {
            fire();
            timeSinceLastShot = Time.time;
        }
    }

    public void fire()
    {
        if (transform.position.x < player.position.x)
        {
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            temp.speed = projectileForce;
        }

        if (transform.position.x > player.position.x)
        {
            Projectile temp = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            temp.speed = -projectileForce;
        }
    }

private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Fireball")
        {
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void flip()
    {
        if (isFacingRight)
        {
            isFacingRight = false;
        }
        if (!isFacingRight)
        {
            isFacingRight = true;
        }
        Vector3 scaleFactor = transform.localScale;
        scaleFactor.x *= -1;
        transform.localScale = scaleFactor;
    }
}