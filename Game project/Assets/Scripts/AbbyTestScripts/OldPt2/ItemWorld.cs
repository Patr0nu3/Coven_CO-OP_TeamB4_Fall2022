using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    // instantiate instance if itemworld
    public static ItemWorld SpawnItemWorld(Vector3 position, Item item) {
        // if (ItemAssets.Instance.pfItemWorld == null) {
        //     Debug.Log("pfItemWorld null");
        // } else {
        //     Debug.Log("not null");
        // }
        Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);
        
        // gets itemworld and sets an item to it
        ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
        itemWorld.SetItem(item);
        
        return itemWorld;
    }
    
    // drops item in world
    public static ItemWorld DropItem(Vector3 dropPosition, Item item) {
        // get a random direction
        Vector3 ranDir = new Vector3(UnityEngine.Random.Range(-1f,1f), 
                            UnityEngine.Random.Range(-1f,1f)).normalized;
        ItemWorld itemWorld = SpawnItemWorld(dropPosition + ranDir * 2f, item);
        itemWorld.GetComponent<Rigidbody2D>().AddForce(ranDir * 3f, ForceMode2D.Impulse);
        return itemWorld;
    }
    
    // the item whose world this is
    private Item item;
    private SpriteRenderer spriteRenderer;
    
    private void Awake() {
        // retrieves the object's sprite renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    // creates an item's itemworld
    public void SetItem(Item item) {
        this.item = item;
        spriteRenderer.sprite = item.GetSprite();
    }
    
    // return what item this is
    public Item GetItem() {
        return item;
    }
    
    // destroys item game object
    public void DestroySelf() {
        Destroy(gameObject);
    }
}
