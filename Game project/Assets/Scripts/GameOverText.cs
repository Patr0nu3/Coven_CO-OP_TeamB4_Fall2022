using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public Game_Handler gameHandler;
    [SerializeField] Text CoinText;
    
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "You Earned " + gameHandler.getCoins().ToString() 
                          + " Coins!";
    }
}
