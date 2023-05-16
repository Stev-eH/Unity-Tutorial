using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    public void ButtonTest()
    {
        Debug.Log("Works!");
    }

    public void StartGame()
    {
        SceneManager.LoadScene( 1, LoadSceneMode.Single);
    }
}
