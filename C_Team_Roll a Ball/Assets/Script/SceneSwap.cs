using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour{
    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.JoystickButton1)){
            SceneManager.LoadScene("SampleScene");
        }
    }
}
