using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T1Submit : MonoBehaviour
{
    public Button yourButton;

	void Start () {
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		Debug.Log ("You have clicked the button!");
        ErrorMessage();
        
	}
    
    void ErrorMessage() {
        Debug.Log("error");
        GameObject msg = new GameObject("err_msg");
        msg.transform.SetParent(this.transform);
        
        msg.AddComponent<Text>().text = "No potion found.";
    }
}
