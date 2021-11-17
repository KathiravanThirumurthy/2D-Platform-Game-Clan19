using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button _startBtn;
    [SerializeField]
    private Button _quitBtn;
    private void Awake()
    {
        _startBtn.onClick.AddListener(StartGame);
        _quitBtn.onClick.AddListener(QuitGame);
    }
    private void StartGame()
    {
       
        SceneManager.LoadScene(1);
    }
    private void QuitGame()
    {
        Application.Quit();
    }
    private void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        Debug.Log("Mouse is over GameObject.");
    }

}
