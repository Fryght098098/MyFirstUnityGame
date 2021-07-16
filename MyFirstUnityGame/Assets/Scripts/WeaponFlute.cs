using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFlute : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;

    int ConsecutiveShot = 0;
    bool CheckedOnce = false;

    private GameObject LoadPrefab;

    public float nextShot = 0f;
    public float shotDelay = 0.5f;
    public float AtkTimeout = 1f;
    private float ShootForce = 0.1f;
  

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        PlayerManager PlayerHp = GameManager.GetComponent<PlayerManager>();
        PlayerHp.SetMaxHealth(70);
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckedOnce == true)
        {
            if (ConsecutiveShot == 2)
            {                
                if (Time.time > nextShot + AtkTimeout + 0.5f)
                {
                    ConsecutiveShot = 0;
                    Debug.Log("Shot rested");
                }

            }
            else if (ConsecutiveShot == 4)
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

                    FluteBullets.bulletDamage = 5;
                }
            }

        }

        if (ConsecutiveShot == 0)
        {
            FluteBullets.bulletDamage = 5;
        }

        if (ConsecutiveShot == 1)
        {
            shotDelay = 1f;
        }

        if (ConsecutiveShot == 2)
        {
            shotDelay = 0.5f;
        }

        if (ConsecutiveShot == 3)
        {
            shotDelay = 1f;
        }

        if (ConsecutiveShot == 4)
        {
            shotDelay = 0.33333f;
        }

        if (ConsecutiveShot == 5)
        {
            FluteBullets.bulletDamage = 3;
        }

        if (ConsecutiveShot == 8)
        {
            shotDelay = 0.5f;
            nextShot += 0.75f;
            ConsecutiveShot = 0;
            Debug.Log(nextShot);
        }

        if (Time.time > nextShot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                LoadPrefab = (GameObject)Resources.Load("Prefabs", typeof(GameObject));

                GameObject Weapon1 = GameObject.Find("Weapon1");
                FluteBullets AccShotDmg = Weapon1.GetComponent<FluteBullets>();

                Debug.Log("Consecutive shots " + ConsecutiveShot);
                //Debug.Log("FIRE!");

                GameObject StartLocation = GameObject.Find("Weapon1");
                GameObject camera = GameObject.Find("Main Camera");
                Transform bullet = Instantiate(pfBullet);
                bullet.transform.position = StartLocation.transform.position;
                bullet.GetComponent<FluteBullets>().Setup();
                Rigidbody projectile = bullet.GetComponent<Rigidbody>();
                projectile.AddForce(camera.transform.forward * ShootForce * Time.deltaTime);

                nextShot = Time.time + shotDelay;
                ConsecutiveShot++;
                CheckedOnce = true;
             
            }
        }
    }           
}
