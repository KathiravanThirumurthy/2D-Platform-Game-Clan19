using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    //public Button restartBtn;
   


    private void Awake()
    {
       // restartBtn.onClick.AddListener(reLoadingLevel);
       // Debug.Log(gObj.name);
    }
    public void playerDead()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        Debug.Log("Reload when Dead");
        StartCoroutine("setTrueLevelCompleted");
        Time.timeScale = 0;
       
    }
    IEnumerator setTrueLevelCompleted()
    {

            yield return new WaitForSecondsRealtime(5.0f);
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Hero _hero = collision.GetComponent<Hero>();
        if (_hero != null)
        {
            _hero.playerDead();
                      
        }
    }
    public void reLoadingLevel()
    {
        Debug.Log("Restart Btn Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
