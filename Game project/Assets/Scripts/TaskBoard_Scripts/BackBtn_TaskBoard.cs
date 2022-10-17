using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtn_TaskBoard : MonoBehaviour
{
    public string LeaveTaskBoard = "MainMap";
    
    void OnMouseDown() {
        // if (Input.GetMouseButtonDown(0)) {
        Debug.Log("clicked");
            SceneManager.LoadScene(LeaveTaskBoard);
        // }
    }

    public void MoveToScene()
    {
        SceneManager.LoadScene(LeaveTaskBoard);
    }
    // void OnMouseDown()
    // {
    //     Debug.Log("clicked");
    //     // Destroy the gameObject after clicking on it
    //     // Destroy(gameObject);
    // }
}