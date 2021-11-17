using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
   /* public Button restartBtn;
    public GameObject gObj;*/

    private void Awake()
    {
        //restartBtn.onClick.AddListener(reLoadingLevel);
       // Debug.Log(gObj.name);
    }
    public void playerDead()
    {
        gameObject.SetActive(true);
    }
    public void ReloadLevel()
    {
        Debug.Log("Reload when Dead");
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
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
    private void reLoadingLevel()
    {
       // gObj.SetActive(true);
    }
}
