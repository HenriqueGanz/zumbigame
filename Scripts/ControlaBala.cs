using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaBala : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody rigidbodyBullet;

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbodyBullet =  GetComponent<Rigidbody>();

        rigidbodyBullet.MovePosition
        (rigidbodyBullet.position + transform.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider objectCollider) {

        if(objectCollider.tag == "Inimigo"){
            Destroy(objectCollider.gameObject);
        }

        Destroy(gameObject);
    }
}
