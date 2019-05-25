using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    string[] fileEntries;
    List<SaveData> listData;
    public GameObject PrefabLoadButoonInfo;

    private void Awake()
    {
        listData = new List<SaveData>();

        //Путь к сохранениям
        string path = Application.dataPath + "/saves";
        //Получение всех файлов сохранений
        fileEntries = Directory.GetFiles(path);
        foreach (string fileName in fileEntries)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();
            try
            {
                SaveData sd = (SaveData)bformatter.Deserialize(fs);
                listData.Add(sd);
            }
            catch (System.Exception e)
            {
                Debug.Log(e.Message + " " + fileName);
            }
            finally
            {
                fs.Close();
            }
        }
        //Если сохранений нет, то нет кнопки продолжить и загрузить
        if (fileEntries.Length == 0)
        {
            transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            listData.Sort();
            listData.Reverse();
            for (int i = 0; i < listData.Count; ++i)
            {
                GameObject newLoadButtonInfo = Instantiate(PrefabLoadButoonInfo, transform.GetChild(1).GetChild(0).GetChild(0));
                newLoadButtonInfo.transform.GetChild(0).GetComponent<Text>().text = listData[i].name;
                newLoadButtonInfo.transform.GetChild(1).GetComponent<Text>().text = listData[i].dataTime.ToShortTimeString() + listData[i].dataTime.ToShortDateString();
                int a = i;
                newLoadButtonInfo.GetComponent<Button>().onClick.AddListener(delegate { LoadGame(a);});
            }
        }
    }

    public void СontinueGame()
    {
        UserData.instance.SaveDataToUserData(listData[0]);
        SceneManager.LoadScene(listData[0].currentSceneID);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGameButton()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void LoadGame(int index)
    {
        Debug.Log(index);
        UserData.instance.SaveDataToUserData(listData[index]);
        SceneManager.LoadScene(listData[index].currentSceneID);
    }
}
