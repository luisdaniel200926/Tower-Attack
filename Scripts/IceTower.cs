using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTower : Towers
{
    private int interval = 15;
    public GameObject prefabBullet;
    public GameObject RotationAxis;
    private float fireCountDown;
    public Transform Canon;

    private float FreezedTimer = -1;
    public AudioClip IceSound;
   

    void Start()
    {
        Range = 7f;
        Damage = 15f;
        TimeToFireRate = 1f;
        StartHealth = 250f;
        Health = StartHealth;
        MoneyValue = 250f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Freezed && FreezedTimer < 0)
        {
            StartFreeze();

        }
        else if (Freezed && FreezedTimer > 0)
        {
            Freezing();
        }
        else
        {
            if (Time.frameCount % interval == 0 && Objective == null)
            {
                SearchNewObjective();
            }
            else if (Time.frameCount % interval == 0 && Vector3.Distance(transform.position, Objective.transform.position) >= Range)
            {

                Objective = null;

            }
            else { }



            if (Objective != null && fireCountDown <= 0f)
            {
                GetComponent<AudioSource>().clip = IceSound;
                GetComponent<AudioSource>().Play();
                Shoot();

                fireCountDown = TimeToFireRate;
            }

            if (Objective != null)
            {
                fireCountDown -= Time.deltaTime;

                Vector3 dir = Objective.transform.position - transform.position;
                Quaternion lookAt = Quaternion.LookRotation(dir);
                Vector3 rotation = lookAt.eulerAngles;
                RotationAxis.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
            }
        }
    }

    public void Shoot()
    {

        GameObject Bullet = Instantiate(prefabBullet, Canon.transform.position, Canon.transform.rotation);
        Bullet.GetComponent<Bullets>().damagebullet = Damage;

        if (Bullet != null)
        {
            Bullet.GetComponent<Bullets>().BulletObjective(Objective);

        }


    }
    public void StartFreeze()
    {
        FreezedTimer = TimeFreezed;
        Debug.Log(FreezedTimer);
        FreezingEffect = Instantiate(FreezeEffectPrefab, this.transform);
    }

    public void Freezing()
    {
        FreezedTimer -= Time.deltaTime;

        Debug.Log("Timer:");
        Debug.Log(FreezedTimer);

        if (FreezedTimer <= 0)
        {
            Destroy(FreezingEffect);
            Freezed = false;
        }
    }

}
