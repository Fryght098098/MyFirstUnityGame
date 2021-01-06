using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    #region Singleton

    public static Target instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

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
