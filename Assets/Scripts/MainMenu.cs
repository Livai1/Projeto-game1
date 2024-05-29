using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    public void CreditsGame()
    {
        isInfo = !isInfo;
        infoObj.SetActive(isInfo);
    }
}
