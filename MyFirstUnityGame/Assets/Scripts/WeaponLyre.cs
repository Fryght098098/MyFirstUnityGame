using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLyre : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;

    int ConsecutiveShot = 0;

    public int PlayerHealth = 80;
    public float nextShot = 0f;
    public float shotDelay = 2/3f;
    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        PlayerManager PlayerHealth = GameManager.GetComponent<PlayerManager>();
        PlayerHealth.hp = 80;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextShot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Consecutive shots " + ConsecutiveShot);
                if (ConsecutiveShot < 4)
                {
                    Debug.Log("FIRE!");
                    GameObject StartLocation = GameObject.Find("Weapon3");
                    Transform bullet = Instantiate(pfBullet);
                    bullet.transform.position = StartLocation.transform.position;
                    /*Vector3 shootDirection = ( X - Y );
                    bullet.GetComponent<LyreBullets>().Setup(shootDirection);*/
                    nextShot = Time.time + shotDelay;
                    ConsecutiveShot++;
                }
                else
                {
                    nextShot += 0.75f;
                    ConsecutiveShot = 0;
                }
            }
        }
    }           
}
