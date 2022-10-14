using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
