using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAcc : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;

    bool CheckedOnce = false;
    int ConsecutiveShot = 0;

    private GameObject LoadPrefab;

    public float nextShot = 0f;
    public float shotDelay = 1f;
    public float AtkTimeout = 1f;
    private float ShootForce = 0.1f;
  

    // Start is called before the first frame update
    void Start()
    {

        GameObject GameManager = GameObject.Find("GameManager");
        PlayerManager PlayerHp = GameManager.GetComponent<PlayerManager>();
        PlayerHp.SetMaxHealth(90);

        AccBullets.bulletDamage = 10;

    }

    // Update is called once per frame
    void Update()
    {
            if (CheckedOnce == true)
        {
            if (ConsecutiveShot >= 2)
            {                
                if (Time.time > nextShot + AtkTimeout + 0.5f)
                {
                    ConsecutiveShot = 0;
                    Debug.Log("Shot reseted");
                }
            }
            else
            {
                if (Time.time > nextShot + AtkTimeout)
                {
                    AccBullets.bulletDamage = 10;

                    ConsecutiveShot = 0;
                    Debug.Log("Shot rested");
                }
            }

        }

        if (ConsecutiveShot == 0)
        {
            AccBullets.bulletDamage = 10;
        }

        if (ConsecutiveShot == 2)
        {
            shotDelay = 0.5f;
        }

        if (ConsecutiveShot == 3)
        {
            AccBullets.bulletDamage = 5;
        }


        if (ConsecutiveShot == 4)
        {
            shotDelay = 1f;
            nextShot += 0.75f;
            ConsecutiveShot = 0;
            Debug.Log(nextShot);
        }

        if (Time.time > nextShot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                LoadPrefab = (GameObject)Resources.Load("Prefabs", typeof(GameObject));

                GameObject Weapon4 = GameObject.Find("Weapon4");
                AccBullets AccShotDmg = Weapon4.GetComponent<AccBullets>();

                Debug.Log("Consecutive shots " + ConsecutiveShot);
                //Debug.Log("FIRE!");
                Debug.Log("Bullet dmg = " + AccBullets.bulletDamage);

                GameObject StartLocation = GameObject.Find("Weapon4");
                GameObject camera = GameObject.Find("Main Camera");
                Transform bullet = Instantiate(pfBullet);
                bullet.transform.position = StartLocation.transform.position;
                bullet.GetComponent<AccBullets>().Setup();
                Rigidbody projectile = bullet.GetComponent<Rigidbody>();
                projectile.AddForce(camera.transform.forward * ShootForce * Time.deltaTime);

                nextShot = Time.time + shotDelay;
                ConsecutiveShot++;
                CheckedOnce = true;
             
            }
        }
    }           
}
