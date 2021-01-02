﻿using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    
    public EnemyHealthBar BosshealthBar;
    public void TakeDamage(float amount)
    {
        health -= amount;

        

        if (health <= 0)
        {
            Die();
        }
        BosshealthBar.SetHealth(health);
    }

    void Die()
    {
        //foreach(gameObject.)
        Destroy(gameObject);
    }

    private void Start()
    {
        BosshealthBar.SetMaxHealth(health);
    }
}
