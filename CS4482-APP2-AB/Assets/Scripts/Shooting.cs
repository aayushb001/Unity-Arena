using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject projectilePrefab;
    public Transform projectileSpawn;
    public float speed = 30;
    public float projectileLifeSpan = 1;
	private float lastShotTime = 0;

    

	void Update () {
        if (projectileSpawn.name.Equals("EnemyGun")) {
            if (!Manager.itState)
            {
                if (Time.time - lastShotTime > 1.5)
                {
                    lastShotTime = Time.time;
                    Shoot();
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Manager.itState)
            {
                if (projectileSpawn.name.Equals("Gun"))
                {
                    Shoot();
                }
            }
        }
	}

    public void Shoot() {
        GameObject projectile = Instantiate(projectilePrefab);
        //Ignore projectile collision with its own spawn entity
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), projectileSpawn.parent.GetComponent<Collider>());
        //Set the spawn point for the projectiles
        projectile.transform.position = projectileSpawn.position;
        //Convert quaternion rotation to vector to read it in angles (0 - 360)
        Vector3 rotation = projectileSpawn.transform.rotation.eulerAngles;
        //We make sure that the bullet is facing out of the gun
        projectile.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);
        projectile.GetComponent<Rigidbody>().AddForce(projectileSpawn.forward * speed, ForceMode.Impulse);
        StartCoroutine(LimitProjectileLifeSpan(projectile, projectileLifeSpan));
    }

    private IEnumerator LimitProjectileLifeSpan(GameObject projectile, float span) {
        yield return new WaitForSeconds(span);
        //Destroy bullet after certain time
        Destroy(projectile);
    }
}
