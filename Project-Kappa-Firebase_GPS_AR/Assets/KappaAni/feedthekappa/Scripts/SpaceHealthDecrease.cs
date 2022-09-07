using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpaceHealthDecrease : MonoBehaviour
{
    public static int health = 100;
    public GameObject player;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
          
        health = health - 5;
        healthBar.value = health;

        }


        if (health <= 20)
        {
            player.GetComponent<Animator>().SetTrigger("isDead");
        }
        else if (health <= 50 && health > 20)
        {
            player.GetComponent<Animator>().SetTrigger("isSick");
        } // InvokeRepeating("ReduceHealth", 1, 1);


    }

    //void ReduceHealth()
    //{

    //     health = health - 5; 
    //    healthBar.value = health;
    //    if (health <= 20)
    //    {
    //        player.GetComponent<Animator>().SetTrigger("isDead");
    //    }
    //    else if (health <= 50 && health > 20)
    //    {
    //        player.GetComponent<Animator>().SetTrigger("isSick");
    //    }


    //    private void Update()
    //    {

    //        if (Input.GetKeyDown(KeyCode.Space))
    //            ReduceHealth(); 
    //
    //     }
    //}
    //// Update is called once per frame
    //void Update()
    //{

    //}
    //
}
