using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    PlayerManager playerManager;
    private int bulletDamage = 10;
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
       
        if (collision.gameObject.name == "***Player ***")
        {
            playerManager = PlayerManager.instance;
            playerManager.hit(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
