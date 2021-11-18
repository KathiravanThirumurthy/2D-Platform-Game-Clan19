using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    /*[SerializeField]
    private Text _gameOverText;*/
    [SerializeField]
    private GameObject gObj;
    [SerializeField]
    private Button restartBtn;
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprites;
    private int score = 0;

    private void Awake()
    {
         _scoreText = GameObject.Find("Canvas").GetComponentInChildren<TextMeshProUGUI>();
       //  restartBtn=GameObject.Find("Canvas").GetComponentInChildren<Button>();
        Debug.Log(restartBtn.onClick.ToString());
        //restartBtn.onClick.AddListener(reLoadingLevel);
        // _scoreText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        refreshUI();
       // restartBtn.onClick.AddListener(reLoadingLevel);
    }

    // Update is called once per frame
    void Update()
    {

    }
   
    public void updateLives(int currentLives)
    {
        //access display images sprite
        // give new one based on current Index
        _livesImage.sprite = _livesSprites[currentLives];
    }
    public void IncreaseScore(int increment)
    {
        score += increment;
        refreshUI();
    }
    private void refreshUI()
    {
        _scoreText.text = "Score:" + score.ToString();
    }
    public void _levelRestart()
    {
      //  Debug.Log("Level restart after the player is dead");
        gObj.SetActive(true);
        StartCoroutine("setTrueLevelCompleted");
        Time.timeScale = 0;
       
    }
    IEnumerator setTrueLevelCompleted()
    {

        yield return new WaitForSecondsRealtime(5.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void reLoadingLevel()
    {
        Debug.Log("Reload");
    }
}
