using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void movement(float move)
    {
        anim.SetFloat("speed", Mathf.Abs(move));
    }
    public void jumping(bool jump)
    {
        anim.SetBool("jump", jump);
    }
    public void flipPlayer(float speed)
    {
        Vector2 scale = transform.localScale;
        if (speed < 0) scale.x = -1.0f * Mathf.Abs(scale.x);
        else if (speed > 0) scale.x = Mathf.Abs(scale.x);
        transform.localScale = scale;
    }
}
