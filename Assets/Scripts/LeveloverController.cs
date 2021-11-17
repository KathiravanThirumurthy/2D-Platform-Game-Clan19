using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LeveloverController : MonoBehaviour
{
    private bool reset;
    public int nextSceneLoad;
    [SerializeField]
    private AudioClip doorTouch;
    private void Awake()
    {
        reset = false;
           nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void Start()
    {
        
    }
    private void Update()
    {

        if(reset)
        {
            
            reload();
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Hero _hero = collision.GetComponent<Hero>();
        if (_hero != null)
        {
            Debug.Log("End of the Game");
            //_uimanager.gameStatus();
            AudioManager.Instance.doorTouch(doorTouch);
            StartCoroutine("setTrueLevelCompleted");
            Time.timeScale = 0;


        }
    }

    IEnumerator setTrueLevelCompleted()
    {
        
        while(!reset)
        {
            yield return new WaitForSecondsRealtime(2.0f);
            reset = true;
            

        }

    }

    private void reload()
    {
       
        //Move to next level
        SceneManager.LoadScene(nextSceneLoad);

        //Setting Int for Index
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }


}
