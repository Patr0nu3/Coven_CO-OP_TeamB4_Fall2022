using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
      public string GameOver = "GameOver";
      // public GameObject player;
      // bool Enter;

      public void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == "Player") {
                  SceneManager.LoadScene (GameOver);
            }
      }
}