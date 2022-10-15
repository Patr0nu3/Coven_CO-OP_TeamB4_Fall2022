using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    public enum ItemType {
        YellowFlower,
        HealthPotion,
        RedMushroom,
        Starfish,
    }
    
    public ItemType itemType;
    public int amount;
    
    // retrieves the sprite associated with the item
    public Sprite GetSprite() {
        switch (itemType) {
            default:
            case ItemType.YellowFlower: 
                 return ItemAssets.Instance.yellowFlowerSprite;
            case ItemType.HealthPotion: 
                 return ItemAssets.Instance.healthPotionSprite;
            case ItemType.RedMushroom: 
                 return ItemAssets.Instance.redMushroomSprite;
            case ItemType.Starfish: 
                 return ItemAssets.Instance.starfishSprite;
        }
    }
    
    public bool IsStackable() {
        switch (itemType) {
            default:
            case ItemType.YellowFlower: 
            case ItemType.RedMushroom: 
            case ItemType.Starfish: 
                 return true;
            case ItemType.HealthPotion: 
                 return false;
            
        }
    }
}
