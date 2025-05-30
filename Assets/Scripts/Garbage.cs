using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
  public float Speed;
  public float velocidadeMaxima = 5f;
  public float forca = 10f;

  private Rigidbody2D rb;
  private int direcao = 0; // -1 esquerda, 1 direita, 0 parado


  public float limiteEsquerda = -25f;
  public float limiteDireita = 5f;
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  void FixedUpdate()
  {
    Vector2 pos = rb.position;

    // Aplica força apenas se dentro dos limites
    if (direcao != 0 && Mathf.Abs(rb.linearVelocity.x) < velocidadeMaxima)
    {
      bool dentroDosLimites =
          (direcao == -1 && pos.x > limiteEsquerda) ||
          (direcao == 1 && pos.x < limiteDireita);

      if (dentroDosLimites)
      {
        rb.AddForce(Vector2.right * direcao * forca);
      }
      else
      {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
      }
    }

    // Limita a posição X
    float posXLimitado = Mathf.Clamp(rb.position.x, limiteEsquerda, limiteDireita);
    rb.position = new Vector2(posXLimitado, rb.position.y);
  }

  public void MoverEsquerda()
  {
    Debug.Log("MoverEsquerda");
    direcao = -1;
  }

  public void MoverDireita()
  {
    Debug.Log("MoverDireita");
    direcao = 1;
  }

  public void Parar()
  {
    Debug.Log("Parar");
    direcao = 0;
    rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y); // Zera a velocidade horizontal
  }

  void Update()
  {
    // Move();
  }

  // void Move()
  // {
  //   Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
  //   transform.position += movement * Time.deltaTime * Speed;
  // }
}
