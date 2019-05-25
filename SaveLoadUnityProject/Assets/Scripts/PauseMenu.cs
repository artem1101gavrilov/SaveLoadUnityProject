using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    GameObject Ball;

    private void Start()
    {
        Ball = GameObject.Find("Ball");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void SaveButton()
    {
        Debug.Log("Save Game");
        if (Ball != null)
        {
            SaveData data = new SaveData(Ball.transform.position, "123");
        }
    }
}
