using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
      public string GameOver = "GameOver";

      public void OnTriggerEnter2D(Collider2D other) {
            // public string GameOver = "GameOver";
            if (other.gameObject.tag == "Player") {
                  SceneManager.LoadScene (GameOver);
            }
            // test for other than player --> reverse its direction? get new one? --> move attackplayer to patrol
      }
}