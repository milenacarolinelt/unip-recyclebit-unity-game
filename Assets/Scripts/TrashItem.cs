using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashItem : MonoBehaviour
{

  private SpriteRenderer sr;
  private BoxCollider2D boxCollider;

  public int Score;

  void Start()
  {
    sr = GetComponent<SpriteRenderer>();
    boxCollider = GetComponent<BoxCollider2D>();
  }

  void OnTriggerEnter2D(Collider2D collider)
  {
      Debug.Log(gameObject);
      Debug.Log(collider.gameObject.tag);
    if (collider.gameObject.tag == "Player")
    {
      sr.enabled = false;
      boxCollider.enabled = false;

      GameController.intance.TotalScore += Score;
      GameController.intance.UpdateScoreText();

      Destroy(gameObject);
    }

    if (collider.gameObject.tag == "Ground" && gameObject.name.Contains("(Clone)"))
    {
      Destroy(gameObject, 1.5f);
    }
  }
}
