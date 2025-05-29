using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garbage : MonoBehaviour
{
  public float Speed;

  void Start()
  {
  }

  void Update()
  {
    Move();
  }

  void Move()
  {
    Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
    transform.position += movement * Time.deltaTime * Speed;
  }
}
