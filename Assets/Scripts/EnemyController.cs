using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enemy");
        Hero _hero = collision.gameObject.GetComponent<Hero>();
        if(_hero != null)
        {

            _hero.killPlayer();
        }
    }
}
