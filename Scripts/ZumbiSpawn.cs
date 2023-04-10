using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZumbiSpawn : MonoBehaviour
{
    public GameObject Zumbi;
    float timer = 0;
    public float SpawnTimer = 1;

    // Update is called once per frame
    void Update()
    {   
        timer = timer + Time.deltaTime;

        if (timer >= SpawnTimer) {
            Instantiate(Zumbi, transform.position, transform.rotation);
            timer = 0;
        }

    }
}
