using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private Rigidbody2D Rigid;

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
        if (col.gameObject.tag == "coin" || col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        
        if (col.gameObject.tag == "Enemy")
        {
            //col.gameObject.GetComponent<EnemyTurret>();
            Destroy(gameObject);
        }
    }
}
