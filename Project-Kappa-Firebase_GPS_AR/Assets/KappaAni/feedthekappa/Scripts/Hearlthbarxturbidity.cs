using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using System.IO.Ports;
//using System.Threading;

public class Hearlthbarxturbidity : MonoBehaviour

{


    const int HEALTHY = 0;
    const int SICK = 1;
    const int DEAD = 2;
    public static float health = 100, currentstate;
    public GameObject player;
    public Slider healthBar;
   

    //public Transform sos;
    //public Vector3 sosbutton;
    //Start is called before the first frame update
    public GameObject uiObject;
    void Start()
    {
        //uiObject.SetActive(false);


    }
    //void triggersos()
    //{
    //    if (currentstate == 2)
    //    {
    //        uiObject.SetActive(true);

    //    }
    //    else
    //    {

    //        Destroy(uiObject);

    //    }
    //}


    //  Update is called once per frame

    void Update()
{
    if (Input.GetKey("down"))
    {
        health = health - 1;
        healthBar.value = health;
    }
    else if (Input.GetKey("up"))
      {
        health = health + 1;
        healthBar.value = health;
    }
    

    if (health > 50 && currentstate == SICK)
    {
        player.GetComponent<Animator>().SetTrigger("isHealthy");
        currentstate = HEALTHY;
            

        }



        else if (health <= 50 && health > 20 && currentstate == HEALTHY)
    {
        player.GetComponent<Animator>().SetTrigger("isSick");
        currentstate = SICK;
          

        }



        else if (health <= 20 && currentstate == SICK)
    {
        player.GetComponent<Animator>().SetTrigger("isDead");
        currentstate = DEAD;
            

            //Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);



        }




    else if (health <= 50 && health > 20 && currentstate == DEAD)
    {
        player.GetComponent<Animator>().SetTrigger("isRecover");
        currentstate = SICK;


        }

        //if (health <= 20)
        //{
        //    uiObject.SetActive(true);
            
        //}
        //else
        //{
            
        //    Destroy(uiObject);

        //}

    }

}



//private void spawnSos()
//{


//    if (health <= 20)
//    {

//        GameObject a = Instantiate(sos) as GameObject;
//        a.transform.position = new Vector3(sos.x, sos.y);
//    }

//}

//public Transform sos;
//public void spawnSos()
//{
//    if (health <= 20)
//    {
//        Instantiate(sos, new Vector3(0, 0, 0), Quaternion.identity);
//    }
//}


//    }
// }
//}
