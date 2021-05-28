using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSpawn : MonoBehaviour
{
    public Transform pos;
    public GameObject[] objectsToInstantiate;
    float min = 1;
    float max = 101;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateObject();
    }

    void Update()
    {

    }

    private void InstantiateObject()
    {
        int r = Random.Range(0, objectsToInstantiate.Length);
        Instantiate(objectsToInstantiate[r], pos.position, objectsToInstantiate[r].transform.rotation);
    }
}