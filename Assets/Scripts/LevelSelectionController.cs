using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectionController : MonoBehaviour
{
    [SerializeField]
    private Button[] levelBtns;
    [SerializeField]
    private GameObject _loader;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        int levelAt = PlayerPrefs.GetInt("levelAt", 2); 
        for (int i = 0; i < levelBtns.Length; i++)
        {
                 if (i + 2 > levelAt)
                levelBtns[i].interactable = false;
        }
    }

    
    public void ChangeScene(int sceneIndex)
    {

        // Debug.Log("sceneName to load: " + sceneIndex);
        StartCoroutine(loadAsynchronously(sceneIndex));
       // SceneManager.LoadScene(sceneIndex);
    }
    IEnumerator loadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            /*if(anim!=null)
            {
                _loader.SetActive(false);
            }*/
            yield return null;
        }
        
    }
    public void deletePref()
    {
        PlayerPrefs.DeleteAll();
    }
    

}
