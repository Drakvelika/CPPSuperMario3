using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Projectile" || Col.gameObject.tag == "EnemyWalker")
        {
            GameManager.instance.lives--;
            Debug.Log("Lives: " + GameManager.instance.lives);
            Destroy(Col.gameObject);
            GameManager.instance.CM.SetLivesText();
        }
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
