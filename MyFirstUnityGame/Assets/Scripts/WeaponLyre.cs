using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLyre : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;

    int ConsecutiveShot = 0;
    bool CheckedOnce = false;

    public float nextShot = 0f;
    public float shotDelay = 2/3f;
    public float AtkTimeout = 1f;
    public float ShootForce = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        PlayerManager PlayerHp = GameManager.GetComponent<PlayerManager>();
        PlayerHp.hp = 80;

        GameObject Lyre = GameObject.Find("Weapon3");
        LyreBullets Force = Lyre.GetComponent<LyreBullets>();
        Force.moveSpeed = ShootForce;
    }

    // Update is called once per frame
    void Update()
    {
        if (CheckedOnce == true)
        {
            if (Time.time > nextShot + AtkTimeout)
            {
                ConsecutiveShot = 0;
                Debug.Log("Shot rested");
            }
        }

        if (ConsecutiveShot == 4)
        {
            nextShot += 0.75f;
            ConsecutiveShot = 0;
        }
 

        if (Time.time > nextShot)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("Consecutive shots " + ConsecutiveShot);
                //Debug.Log("FIRE!");
                GameObject StartLocation = GameObject.Find("Weapon3");
                Transform bullet = Instantiate(pfBullet);
                bullet.transform.position = StartLocation.transform.position;
                Rigidbody projectile = GetComponent<Rigidbody>();
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * ShootForce);
                /*projectile.velocity = ;
                Vector3 LyreShootDirection = (X - Y).normalized;
                bullet.GetComponent<LyreBullets>().Setup(LyreShootDirection);*/
                nextShot = Time.time + shotDelay;
                ConsecutiveShot++;
                CheckedOnce = true;
             
            }
        }
    }           
}
