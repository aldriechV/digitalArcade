using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public static bool GameStart = false;
    public GameObject startMenuUI;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        GameStart = true;
        startMenuUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
