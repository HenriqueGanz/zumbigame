using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaJogador : MonoBehaviour
{
    private Vector3 direction;
    public float speed = 10;
    public LayerMask floorMask;
    public GameObject textGameOver;
    public bool Alive = true;

    private Rigidbody rigidbodyPlayer;
    private Animator animatorPlayer;

    private void Start() {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Inputs do Jogador - Guardando teclas apertadas
        float axisX = Input.GetAxis("Horizontal");
        float axisZ = Input.GetAxis("Vertical");

        direction = new Vector3(axisX, 0, axisZ);

        //Animações do Jogador
        animatorPlayer = GetComponent<Animator>();

       if(direction != Vector3.zero) {

        animatorPlayer.SetBool("Moving", true);

       } else {
        animatorPlayer.SetBool("Moving", false);
       }

       if(Alive == false) {
        
        if(Input.GetButtonDown("Fire1")) {
            SceneManager.LoadScene("game");
        }
       }
    }

    void FixedUpdate() {

        rigidbodyPlayer = GetComponent<Rigidbody>();

        //Movimentação do Jogador por segundo
        rigidbodyPlayer.MovePosition
        (rigidbodyPlayer.position + 
        (direction * speed * Time.deltaTime));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);

        RaycastHit impact;

        if(Physics.Raycast(raio, out impact, 100, floorMask)) {
            Vector3 posicaoMiraJogador = impact.point - transform.position;

            posicaoMiraJogador.y = transform.position.y;

            Quaternion newRotation = Quaternion.LookRotation(posicaoMiraJogador);
            rigidbodyPlayer.MoveRotation(newRotation);
        }
    }
}
