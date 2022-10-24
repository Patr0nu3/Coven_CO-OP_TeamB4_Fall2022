using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    // private GameObject player;
    [SerializeField] private UI_Inventory uiInventory;
    [SerializeField] private Player player;
    
    public static GameHandler gameHandler;
    private InventoryA inventory;

    private void Start()
    {
    }

    public void playerDies(){
        //player.GetComponent<PlayerHurt>().playerDead();      //play Death animation
        //StartCoroutine(DeathPause());
    }

    //IEnumerator DeathPause(){
        //player.GetComponent<PlayerMove>().isAlive = false;
        //player.GetComponent<PlayerJump>().isAlive = false;
        //yield return new WaitForSeconds(1.0f);
        //SceneManager.LoadScene("EndLose");
    //}

    public void StartGame() {
        //SceneManager.LoadScene("Level1");
    }

    public void RestartGame() {
        //SceneManager.LoadScene("MainMenu");
        //playerHealth = StartPlayerHealth;
    }

    public void QuitGame() {
            //if UNITY_EDITOR
            //UnityEditor.EditorApplication.isPlaying = false;
            //else
                //Application.Quit();
                //endif
      }

      public void Credits() {
            //SceneManager.LoadScene("Credits");
      }

}

