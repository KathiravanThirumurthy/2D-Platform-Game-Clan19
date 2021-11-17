using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyspin : MonoBehaviour
{
    private int keyScore;
    private Hero _hero;
   
    private void Awake()
    {
       /*if(_hero == null)
        {
            Debug.LogError("Hero COmponent is not found");
        }*/
    }
    private void Update()
    {
              
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hero = collision.gameObject.GetComponent<Hero>();
        if(_hero!=null)
        {
            _hero.pickUpKey(10);
            Destroy(this.gameObject);
        }
    }
}
