using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class SaveData{
    float positionX;
    float positionY;
    float positionZ;
    float currentSceneID;
    string name;

    public SaveData(Vector3 position, string namePerson)
    {
        positionX = position.x;
        positionY = position.y;
        positionZ = position.z;
        currentSceneID = SceneManager.GetActiveScene().buildIndex;
        name = namePerson;
        SaveGame();
    }

    public void SaveGame()
    {
        if (!Directory.Exists(Application.dataPath + "/saves")) Directory.CreateDirectory(Application.dataPath + "/saves");
        FileStream fs = new FileStream(Application.dataPath + "/saves/" + name + ".sv", FileMode.Create);
        BinaryFormatter bformatter = new BinaryFormatter();
        bformatter.Serialize(fs, this);
        fs.Close();
    }
}
