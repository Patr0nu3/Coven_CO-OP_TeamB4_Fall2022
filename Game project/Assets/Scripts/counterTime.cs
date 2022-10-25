using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class counterTime : MonoBehaviour
{
    //Timer
    float currentTime = 0f;
    public float startingTime = 1000f;

    [SerializeField] Text countdownText;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 30){
            countdownText.color = Color.red;
        }

        int minutes = (int) currentTime/60;
        float seconds = currentTime%60;

        countdownText.text = minutes.ToString("00") + ":" + seconds.ToString("00"); //currentTime.ToString("0");

        if (currentTime <= 0){
            currentTime = 0;
            SceneManager.LoadScene("GameOver");
        }
    }
}
