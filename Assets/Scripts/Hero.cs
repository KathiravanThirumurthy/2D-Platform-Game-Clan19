using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    private bool isGrounded;
    private Rigidbody2D rgd;
    private SpriteRenderer sr;
    private PlayerAnimation _playerAnimation;
    // Start is called before the first frame update
    private void Awake()
    {
        /*if(_playerAnimation == null)
        {
            Debug.LogError("PlayerAnimation is null");
        }*/
        rgd = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        isGrounded = false;
        _playerAnimation = GetComponent<PlayerAnimation>();
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
    
}
