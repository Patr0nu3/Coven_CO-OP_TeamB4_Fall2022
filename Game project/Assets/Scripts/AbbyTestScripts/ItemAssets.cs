using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
    // static field to access this script
    public static ItemAssets Instance { get; private set; }
    
    private void Awake() {
        Instance = this; 
    }
    
    // item world prefab, instantiated in ItemWorld.cs
    public Transform pfItemWorld;
    
    // ALL OF OUR ASSETS (add more here as we get more)
    // also need to add it to switch case in Item.cs for function GetSprit
    public Sprite yellowFlowerSprite;
    public Sprite healthPotionSprite;
    public Sprite redMushroomSprite;
    public Sprite starfishSprite;
}
