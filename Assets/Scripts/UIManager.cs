using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    /*[SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _scoreText;*/
  
    [SerializeField]
    private Image _livesImage;
    [SerializeField]
    private Sprite[] _livesSprites;

    private void Awake()
    {
     
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
}
