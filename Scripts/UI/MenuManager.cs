using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenuUI, debuggerMenu;

    [SerializeField]
    private GameObject[] UIToHideWhenPause, UIToHideWhenDebugger;

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void LoadMenuScene()
    {
        Time.timeScale = 1f;
        GameObject debugger = FindObjectOfType<DebuggerMenu>().gameObject;
        Destroy(debugger);
        SceneManager.LoadScene("Menu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        for (int i = 0; i < UIToHideWhenPause.Length; i++)
            UIToHideWhenPause[i].SetActive(false);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseGame()
    {
        for (int i = 0; i < UIToHideWhenPause.Length; i++)
            UIToHideWhenPause[i].SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowDebugger()
    {
        for (int i = 0; i < UIToHideWhenDebugger.Length; i++)
            UIToHideWhenDebugger[i].SetActive(false);
        debuggerMenu.SetActive(true);
    }

    public void HideDebugger()
    {
        for (int i = 0; i < UIToHideWhenDebugger.Length; i++)
            UIToHideWhenDebugger[i].SetActive(true);
        debuggerMenu.SetActive(false);
    }
}
