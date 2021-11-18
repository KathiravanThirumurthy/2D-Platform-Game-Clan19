using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private AudioClip keyPickup;
    private bool isGrounded;
    private Rigidbody2D rgd;
    private SpriteRenderer sr;
    private PlayerAnimation _playerAnimation;
    
    private int gameLives;
    private UIManager _uimanager;

    private GameOverController _gamecontroller;
    // Start is called before the first frame update
    private void Awake()
    {
        /*if(_playerAnimation == null)
        {
            Debug.LogError("PlayerAnimation is null");
        }*/
        _uimanager = GameObject.Find("Canvas").GetComponent<UIManager>();
        rgd = GetComponent<Rigidbody2D>();
        _gamecontroller = GameObject.Find("Dead").GetComponent<GameOverController>();
        _playerAnimation = GetComponent<PlayerAnimation>();

      
    }
    void Start()
    {
        isGrounded = false;
        gameLives = 3;

    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        _playerAnimation.flipPlayer(move);
        
        if(Input.GetKeyDown(KeyCode.Space))
        {

            if(isGrounded)
            {
                rgd.velocity = new Vector2(rgd.velocity.x,_jumpForce);
                isGrounded = false;
                _playerAnimation.jumping(true);
            }
        }
        rgd.velocity = new Vector2(move * _speed, rgd.velocity.y);
        _playerAnimation.movement(move);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
             isGrounded = true;
            _playerAnimation.jumping(false);
        }
       
    }
    
    public void pickUpKey(int score)
    {
        Debug.Log("Key pickedup");
        AudioManager.Instance.PlayCollectable(keyPickup);
        _uimanager.IncreaseScore(score);
       // _score.IncreaseScore(score);

    }
    
    public void playerDead()
    {
        Debug.Log("Player Dead - Restart the Level");
        _uimanager._levelRestart();
       // _gamecontroller.ReloadLevel();
    }

    public void killPlayer()
    {

        gameLives--;
         Debug.Log(gameLives);
        _uimanager.updateLives(gameLives);

        if (gameLives < 0)
        {

            Debug.Log("Player Killed by the EnemyChomper ");
        }
        else if (gameLives == 0)
        {
            // animator.SetBool("dead", true);
            _uimanager._levelRestart();
             Debug.Log("Remaining Lives : "+ gameLives);
        }


    }

}
