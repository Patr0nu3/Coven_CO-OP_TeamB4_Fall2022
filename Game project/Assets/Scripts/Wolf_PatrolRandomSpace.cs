using System.Collections;
using System.Collections.Generic;
// using System;
using UnityEngine;

public class Wolf_PatrolRandomSpace : MonoBehaviour
{
    public Animator anim;
    public float speed = 10f;
       private float waitTime;
       public float startWaitTime = 2f;

       public Transform moveSpot;
       public float minX;
       public float maxX;
       public float minY;
       public float maxY;

       void Start(){
              waitTime = startWaitTime;
              float randomX = Random.Range(minX, maxX);
              float randomY = Random.Range(minY, maxY);
              moveSpot.position = new Vector2(randomX, randomY);
              
              anim = gameObject.GetComponentInChildren<Animator> ();
       }

       void Update(){
              transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

              if (Vector2.Distance(transform.position, moveSpot.position) < 0.2f){
                     if (waitTime <= 0){
                            float randomX = Random.Range(minX, maxX);
                            float randomY = Random.Range(minY, maxY);
                            moveSpot.position = new Vector2(randomX, randomY);
                            waitTime = startWaitTime;
                            anim.SetBool("run", true);
                     } else {
                            waitTime -= Time.deltaTime;
                            anim.SetBool("run", false);
                     }
              }
       }
}
