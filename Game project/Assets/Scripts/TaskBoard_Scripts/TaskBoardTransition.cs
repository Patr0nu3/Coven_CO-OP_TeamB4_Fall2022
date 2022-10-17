using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskBoardTransition : MonoBehaviour
{
      public string EnterTaskBoard = "ViewTaskBoard";
      public GameObject player;
      bool Enter;

      public void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.tag == "Player" && Enter) {
                  Enter = false;
                  DontDestroyOnLoad(player);
                  SceneManager.LoadScene (EnterTaskBoard);
            }
      }

      public void OnTriggerExit2D(Collider2D other) {
            Enter = true;
      }
}

