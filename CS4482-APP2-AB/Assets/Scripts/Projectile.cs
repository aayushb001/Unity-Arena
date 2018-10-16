using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void OnTriggerEnter(Collider obj)
    {
        Debug.Log(obj.name);

        if (!Manager.itState)
        {
            if (obj.name == "GreenSoldier")
            {
                Manager.itState = true;
                Manager.enemyScore++;
                Debug.Log(Manager.enemyScore + "  " + Manager.playerScore);
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
                Manager.playerScore++;
                Debug.Log(Manager.enemyScore + "  " + Manager.playerScore);
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
