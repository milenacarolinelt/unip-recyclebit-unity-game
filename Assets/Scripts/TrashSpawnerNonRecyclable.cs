using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashSpawnerNonRecyclable : MonoBehaviour
{
  public GameObject[] objetosPrefabs;  // Array com todos os prefabs possíveis
  public float intervalo = 1f;         // Tempo entre cada spawn
  public float rangeX = 10f;           // Alcance aleatório no eixo X
  public float alturaY = 0;          // Altura de onde os objetos caem

  public float velocidadeQueda = -10f;

  public int Score;

  public static TrashSpawnerNonRecyclable intance;

  void Start()
  {
    intance = this;
  }

  public void initSpawner()
  {
    InvokeRepeating("SpawnNonRecyclableObjeto", 0f, intervalo);
  }

  public void stopSpawner()
  {
    CancelInvoke("SpawnNonRecyclableObjeto");
  }

  void SpawnNonRecyclableObjeto()
  {
    CreateSpawnNonRecyclableObjeto();    
    if (GameController.intance.Difficulty > 1)
    {
      Invoke("CreateSpawnNonRecyclableObjeto", 5f);
    }
  }

void CreateSpawnNonRecyclableObjeto()
  {
    // Debug.Log("SpawnNonRecyclableObjeto");

    // Escolhe um prefab aleatoriamente
    int indiceAleatorio = Random.Range(0, objetosPrefabs.Length);
    GameObject prefabSelecionado = objetosPrefabs[indiceAleatorio];

    Rigidbody2D rb = prefabSelecionado.GetComponent<Rigidbody2D>();
    rb.gravityScale = GameController.intance.GravityScale; // Padrão é 1. Menores valores = queda mais lenta
    rb.linearVelocity = new Vector3(0, velocidadeQueda, 0);

    // Define a posição aleatória no eixo X
    float posX = Random.Range(-rangeX, rangeX);
    Vector3 posicaoSpawn = new Vector3(posX, alturaY, 0);

    // Instancia o objeto
    Instantiate(prefabSelecionado, posicaoSpawn, Quaternion.identity);

  }


}
