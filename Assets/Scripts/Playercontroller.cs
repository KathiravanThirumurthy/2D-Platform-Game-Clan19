using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jump;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField]
    private BoxCollider2D Player_Collider;
    private SpriteRenderer sr;
    private float m_ScaleX, m_ScaleY, m_ScaleZ;
    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        Player_Collider = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        isGrounded = true;
        
        m_ScaleX = Player_Collider.size.x;
        m_ScaleY = Player_Collider.size.y;
        // m_ScaleZ = Player_Collider.size.z;
        Debug.Log("Current Sprite Size before: " + sr.sprite.bounds.size);
        Debug.Log("Current BoxCollider Size before: " + Player_Collider.size);

    }
        // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        // playerInput();
        movePlayer(horizontal,vertical);
        playerMovementAnimation(horizontal, vertical);
    }
    private void playerMovementAnimation(float horizontal,float vertical)
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontal));
        flipPlayer(horizontal);
        jumpPlayer(vertical);
        if (Input.GetKeyDown(KeyCode.RightControl) || Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            animator.SetBool("crouch", true);
            print("Control key was pressed");
            print("Sprite bound size:"+sr.sprite.bounds.size/2);
                    
            /* m_ScaleX = sr.sprite.bounds.size.x;
             m_ScaleY = sr.sprite.bounds.size.y;*/

            //Player_Collider.size = new Vector3(m_ScaleX, m_ScaleY);
            Player_Collider.size = new Vector3(1.13f, 1.64f);
            Player_Collider.offset = new Vector3(0f,0.63f);
            Debug.Log("Current BoxCollider Size : " + Player_Collider.size);
            /*Destroy(Player_Collider);
            gameObject.AddComponent<BoxCollider2D>();
            x=1.07,y=1.2 offx=-0.13,y=0.63
            jump x=1.07y=1.8 , xoff=0.07547355 yoff=1.6
             */

        }
        else if (Input.GetKeyUp(KeyCode.RightControl) || Input.GetKeyUp(KeyCode.LeftControl))
        {
            animator.SetBool("crouch", false);
            Player_Collider.size = new Vector3(0.6f, 2.3f);
            Player_Collider.offset = new Vector3(0f, 0.98f);
            // print("Control key was release");
        }
       
    }
    private void crouchPlayer(float vertical)
    {
        animator.SetBool("crouch", true);
        print("Control key was pressed");
    }
    private void jumpPlayer(float vertical)
    {
        if (vertical > 0)
        {
             animator.SetBool("jump", true);
            Player_Collider.size = new Vector3(1f, 1.8f);
            Player_Collider.offset = new Vector3(0f, 1.6f);

        }
            
        else
        {
            animator.SetBool("jump", false);
            Player_Collider.size = new Vector3(0.6f, 2.3f);
            Player_Collider.offset = new Vector3(0f, 0.98f);
        }
            
    }
    private void movePlayer(float horizontal,float vertical)
    {
        Vector3 temp = transform.position;
        temp.x = temp.x + horizontal * speed * Time.deltaTime;
        transform.position = temp;
        if (vertical > 0)
        {
            if(isGrounded)
            {
                rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
                // rb.AddForce(Vector2.up * jump * Time.deltaTime);
                isGrounded = false;
            }
            

        }

       

    }
    void playerInput()
    {
        
        float speedJump = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed", Mathf.Abs(speed));
              
    }
    void flipPlayer(float speed)
    {
        Vector2 scale = transform.localScale;
        if (speed < 0)scale.x = -1.0f * Mathf.Abs(scale.x);
        else if (speed > 0) scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
        }
    }
}
