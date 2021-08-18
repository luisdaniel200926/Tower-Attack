using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giant : Minions
{

    public bool CanBlock;
    public int Blocks;
    public GameObject Shield;
    private Vector3 ShieldSize;

    private float _timer;
    private float TimeShieldGetsBig=.2f;
    public AudioClip ShieldSound;

    void Start()
    {
        CanBlock = false;
        ShieldSize = Shield.transform.localScale;

        starthealth = 100;
        startSpeed = 1;
      
        playerManager = GameObject.FindGameObjectWithTag("Player");

        speed = startSpeed;
        health = starthealth;
        i = 0;
        NextPoint = PointsScript.Points[0];


        int random = Random.Range(1, 100);
        if (random <= 40)
        {
            CanBlock = true;
            int randomBlocks = Random.Range(1, 4);
            Blocks = randomBlocks;

        }
      

    }


    void Update()
    {
        if ((Vector3.Distance(transform.position, NextPoint.position)) <= .5)
        {
            FindNextPoint();
        }

        Move();

        _timer -= Time.deltaTime;
        if (_timer <= 0 ) { Shield.transform.localScale = ShieldSize; }

        if (timerSlow > 0) { timerSlow -= Time.deltaTime; }
        if (timerSlow <= 0) { speed = startSpeed; TryDestoryLight(); }

    }

    //Overriden so we can apply the blocks
    public override void MakeDamage(float Damage)
    {
        
        if (Blocks > 0)
        {
            Blocks--;
            GetComponent<AudioSource>().clip = ShieldSound;
            GetComponent<AudioSource>().Play();
            Shield.transform.localScale =  new Vector3(.15f, .08f, .15f);

            _timer = TimeShieldGetsBig;

        }

        else { 

            health -= Damage;

            healthbar.fillAmount = health / starthealth;

            if (health <= 0)
            {
                Destroy(gameObject);
                return;
            }

        }
    }

}
