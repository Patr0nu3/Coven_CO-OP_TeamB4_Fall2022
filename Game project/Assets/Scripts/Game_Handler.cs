using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Game_Handler : MonoBehaviour
{
    public static GameHandler gameHandler;

    public inventories playerInventory;
    public static bool GameisPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer mixer;
    public static float volumeLevel = 1.0f;
    private Slider sliderVolumeCtrl;
    
    // coin collection
    private int coins;

    void Awake (){
                SetLevel (volumeLevel);
                GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                if (sliderTemp != null){
                        sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                        sliderVolumeCtrl.value = volumeLevel;
                }
    }

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        GameisPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameisPaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    void Pause(){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameisPaused = true;
    }

    public void Resume(){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            GameisPaused = false;
    }

    public void SetLevel (float sliderValue){
            mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
            volumeLevel = sliderValue;
    }

    public void StartGame() {
        SceneManager.LoadScene("MainMap");
        rmAllItems();
    }

    public void Credits() {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                rmAllItems();
                coins = 0;
                Application.Quit();
                #endif
      }

    public void MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void ResetGame() {
        rmAllItems();
        coins = 0;
        Debug.Log("reset game");
    }

    private void rmAllItems() {
        for (int i = 0; i < playerInventory.itemList.Count; i++) {
            playerInventory.itemList[i].itemHeld = 0;
        }
        playerInventory.itemList.Clear();
    }
    
    //
    // functions related to coin collection
    //
    public int getCoins() {
        return coins;
    }
    
    public void updateCoins(int val) {
        coins += val;
    }
    
}

