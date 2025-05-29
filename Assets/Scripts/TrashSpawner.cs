using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
  public GameObject[] objetosPrefabs;  // Array com todos os prefabs possíveis
  public float intervalo = 1f;         // Tempo entre cada spawn
  public float rangeX = 10f;           // Alcance aleatório no eixo X
  public float alturaY = 0;          // Altura de onde os objetos caem

  public float velocidadeQueda = -10f;

  public int Score;

  public static TrashSpawner intance;

  void Start()
  {
    intance = this;
  }

  public void initSpawner()
  {
    InvokeRepeating("SpawnObjeto", 0f, intervalo);
  }

  public void stopSpawner()
  {
    CancelInvoke("SpawnObjeto");
  }

  void SpawnObjeto()
  {
    // Debug.Log("SpawnObjeto");

    // Escolhe um prefab aleatoriamente
    int indiceAleatorio = Random.Range(0, objetosPrefabs.Length);
    GameObject prefabSelecionado = objetosPrefabs[indiceAleatorio];

    Rigidbody2D rb = prefabSelecionado.GetComponent<Rigidbody2D>();
    rb.gravityScale = 0.2f; // Padrão é 1. Menores valores = queda mais lenta
    rb.linearVelocity = new Vector3(0, velocidadeQueda, 0);

    // Define a posição aleatória no eixo X
    float posX = Random.Range(-rangeX, rangeX);
    Vector3 posicaoSpawn = new Vector3(posX, alturaY, 0);

    // Instancia o objeto
    Instantiate(prefabSelecionado, posicaoSpawn, Quaternion.identity);
  }

}
