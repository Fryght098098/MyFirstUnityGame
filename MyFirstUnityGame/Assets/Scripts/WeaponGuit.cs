using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGuit : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;

    int ConsecutiveShot = 0;
    bool CheckedOnce = false;

    private GameObject LoadPrefab;

    public float nextShot = 0f;
    public float shotDelay = 2f;
    public float AtkTimeout = 1f;
    private float ShootForce = 0.1f;
  

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        PlayerManager PlayerHp = GameManager.GetComponent<PlayerManager>();
        PlayerHp.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckedOnce == true)
        {
            if (ConsecutiveShot >= 3)
            {                
                if (Time.time > nextShot + AtkTimeout + 0.5f)
                {
                    ConsecutiveShot = 0;
                    Debug.Log("Shot rested");
                }

            }
            else
            {
                if (Time.time > nextShot + AtkTimeout)
                {
                    ConsecutiveShot = 0;
                    Debug.Log("Shot rested");

                    GuitBullets.bulletDamage = 20;
                }
            }

        }

        if (ConsecutiveShot == 0)
        {
            GuitBullets.bulletDamage = 20;
        }

        if (ConsecutiveShot == 3)
        {
            shotDelay = 1f;
        }

        if (ConsecutiveShot == 4)
        {
            GuitBullets.bulletDamage = 10;
        }

        if (ConsecutiveShot == 5)
        {
            shotDelay = 2f;
            nextShot += 0.75f;
            ConsecutiveShot = 0;
            Debug.Log(nextShot);
        }

        if (Time.time > nextShot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                LoadPrefab = (GameObject)Resources.Load("Prefabs", typeof(GameObject));

                GameObject Weapon2 = GameObject.Find("Weapon2");
                GuitBullets AccShotDmg = Weapon2.GetComponent<GuitBullets>();

                Debug.Log("Consecutive shots " + ConsecutiveShot);
                //Debug.Log("FIRE!");

                GameObject StartLocation = GameObject.Find("GuitCenter");
                GameObject camera = GameObject.Find("Main Camera");
                Transform bullet = Instantiate(pfBullet);
                bullet.transform.position = StartLocation.transform.position;
                bullet.GetComponent<GuitBullets>().Setup();
                Rigidbody projectile = bullet.GetComponent<Rigidbody>();
                projectile.AddForce(camera.transform.forward * ShootForce * Time.deltaTime);

                nextShot = Time.time + shotDelay;
                ConsecutiveShot++;
                CheckedOnce = true;
             
            }
        }
    }           
}
