// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// 
// public class TaskBoardTransition : MonoBehaviour
// {
//     public string EnterTaskBoard = "ViewTaskBoard";
// 
//     public void OnTriggerEnter2D(Collider2D other) {
//         if (other.gameObject.tag == "Player") {
//             SceneManager.LoadScene (EnterTaskBoard);
//         }
//     }
// }

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TaskBoardTransition : MonoBehaviour
{
    public string EnterTaskBoard = "ViewTaskBoard";

      public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  SceneManager.LoadScene (EnterTaskBoard);
            }
      }
}

