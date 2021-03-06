﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider obj)
    {

        if (!Manager.itState)
        {
            if (obj.name == "GreenSoldier")
            {
                Manager.itState = true;
                //Manager.enemyScore++;
                destroyProjectiles("ProjectileEnemy");
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (Manager.itState)
        {
            if (obj.name == "BlueSoldier")
            {
                Manager.itState = false;
                //Manager.playerScore++;
                destroyProjectiles("Projectile");
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }
    private void destroyProjectiles(string name)
    {
        GameObject[] dest = GameObject.FindGameObjectsWithTag(name);
        foreach (GameObject go in dest)
        {
            Destroy(go);
        }
    }

}
