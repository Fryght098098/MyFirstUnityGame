using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitBullets : MonoBehaviour
{
    Target EnemyDmg;
    public static int bulletDamage = 20;
    public float moveSpeed;

    public void Setup()
    {
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider collision)
    {
        Physics.IgnoreLayerCollision(10, 11, true);
        Physics.IgnoreLayerCollision(10, 12, true);

        if (collision.gameObject.name == "*** Enemy1 ***")
        {
            EnemyDmg = Target.instance;
            EnemyDmg.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
