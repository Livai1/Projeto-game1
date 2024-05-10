using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject infoObj;
    private bool isInfo;

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void infoLoad()
    {
        isInfo = !isInfo;
        infoObj.SetActive(isInfo);
    }
}
