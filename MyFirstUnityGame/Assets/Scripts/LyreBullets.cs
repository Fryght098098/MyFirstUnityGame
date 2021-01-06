using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyreBullets : MonoBehaviour
{
    Target EnemyDmg;
    private int bulletDamage = 7;
    private Vector3 shootDir;
    public float moveSpeed = 1f;
    public void Setup(Vector3 shootDirection)
    {
        shootDir = shootDirection;
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {

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
