using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Awake()
    {
        string path = Application.dataPath + "/saves/";
        if (!Directory.Exists(path) )
        {
            string[] fileEntries = Directory.GetFiles(path);
            foreach (string fileName in fileEntries)
                Debug.Log(fileName);
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
    }

    public void СontinueGame()
    {

    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {

    }
}
