using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public PlayerHealthBarScript healthBar;

    public void hit(int damage)
    {
        hp -= damage;

        healthBar.SetHealth(hp);

        if (hp <= 0)
        {
            handleDeath();
        }
    }

    public void handleDeath()
    {
        Debug.Log("You dead!");
        Application.Quit();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    void Start()
    {
        healthBar.SetMaxHealth(hp);
    }
}
