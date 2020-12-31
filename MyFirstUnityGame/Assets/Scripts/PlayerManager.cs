using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public int hp = 100;

    public void hit(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            handleDeath();
        }
    }

    public void handleDeath()
    {
        Debug.Log("You dead!");
        Application.Quit();
    }
}
