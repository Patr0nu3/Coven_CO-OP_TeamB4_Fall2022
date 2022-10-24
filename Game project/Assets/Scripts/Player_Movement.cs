using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 7f;
    public Vector2 movement;
    public GameObject myBag;
    bool bagIsOpen;

    //public Tilemap obstacles;

    private static Player_Movement instance = null;

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else if (instance != this) {
            Destroy(this.gameObject);
            return;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        openInventory();
    }

    void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void openInventory()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            bagIsOpen = !bagIsOpen;
            myBag.SetActive(bagIsOpen);
        }
    }
}
