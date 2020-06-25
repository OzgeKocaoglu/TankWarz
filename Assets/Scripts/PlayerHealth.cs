using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 100;


    public void GetDamage()
    {
        Health -= Random.Range(15,30);
        Death();
    }

    public void Death()
    {
        if(Health <= 0)
        {
            Debug.Log("One player is death");
            Destroy(this.gameObject);
        }
    }
}
