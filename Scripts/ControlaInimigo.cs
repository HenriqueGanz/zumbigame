using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Player;
    public float speed = 2;
    private Rigidbody rigidBodyInimigo;
    private Animator animatorInimigo;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        int SkinGenerator = Random.Range(1, 28);
        transform.GetChild(SkinGenerator).gameObject.SetActive(true);
    }

    void FixedUpdate() {
          rigidBodyInimigo = GetComponent<Rigidbody>();
          animatorInimigo = GetComponent<Animator>();

        float distance = Vector3.Distance(transform.position, Player.transform.position);
        Vector3 direction = Player.transform.position - transform.position;


       Quaternion newRotation = Quaternion.LookRotation(direction);
            rigidBodyInimigo.MoveRotation(newRotation);    

       if(distance > 2.8) {

            rigidBodyInimigo.MovePosition
            (rigidBodyInimigo.position + direction.normalized * speed * Time.deltaTime);

            animatorInimigo.SetBool("Atacando", false);
       }else {
            animatorInimigo.SetBool("Atacando", true);
       }     
    }

    void AtacaJogador () {
        Time.timeScale = 0;
        Player.GetComponent<ControlaJogador>().textGameOver.SetActive(true);
        Player.GetComponent<ControlaJogador>().Alive = false;
    }
}
