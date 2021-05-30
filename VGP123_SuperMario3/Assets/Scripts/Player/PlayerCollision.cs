using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collision2D Col)
    {
        if (Col.gameObject.tag == "Projectile")
        {
            GameManager.instance.lives--;
            Debug.Log("Lives: " + GameManager.instance.lives);
            Destroy(Col.gameObject);

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
