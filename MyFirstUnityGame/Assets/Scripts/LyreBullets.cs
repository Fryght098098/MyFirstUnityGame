using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyreBullets : MonoBehaviour
{
    Target EnemyDmg;
    private int bulletDamage = 7;
    public float moveSpeed;

    public void Setup()
    {
        Destroy(gameObject, 10f);
    }

    void OnTriggerEnter(Collider collision)
    {
        Physics.IgnoreLayerCollision(10, 11, true);

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
