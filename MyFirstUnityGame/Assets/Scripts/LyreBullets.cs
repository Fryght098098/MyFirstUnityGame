using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LyreBullets : MonoBehaviour
{
    Target EnemyDmg;
    private int bulletDamage = 7;
    private Vector3 LyreShootDir;
    public float moveSpeed;
    public void Setup(Vector3 LyreShootDirection)
    {
        LyreShootDir = LyreShootDirection;
        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        transform.position += LyreShootDir * moveSpeed * Time.deltaTime;
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
