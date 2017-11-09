using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour {

    public void BackToMenuButtonClicked()
    {
        //Load the next scene
        SceneManager.LoadScene("TitleScene");
    }
}
