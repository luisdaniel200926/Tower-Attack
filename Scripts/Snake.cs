using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : Minions
{
    private float slidetime;
    private float _timer;
    private bool Sliding;

    public float ExtraSpeed;


    void Start()
    {
        Sliding = false;
        slidetime = 1.5f;
        ExtraSpeed = 2f;

        starthealth = 10f;
        startSpeed = 2.5f;
        
       
        playerManager = GameObject.FindGameObjectWithTag("Player");

        speed = startSpeed;
        health = starthealth;
        Freezed = false;
        i = 0;
        NextPoint = PointsScript.Points[0];

    }

    void Update()
    {
        if ((Vector3.Distance(transform.position, NextPoint.position)) <= .5)
        {

            FindNextPoint();


        }

        Move();

        int random = Random.Range(1, 10000);
        

        if (random <= 10) {
            Debug.Log(random);
            Sliding = true;
            _timer = slidetime;
        }

        //All the different states of the snake

        if(Sliding && _timer > 0  ) { Slide(); }

        if (_timer > 0) { _timer -= Time.deltaTime; }

        if(Sliding && _timer <= 0 ) { Sliding = false;  speed = startSpeed; }

        if (timerSlow > 0) { timerSlow -= Time.deltaTime; }

        if (timerSlow <= 0 && Freezed) { speed = startSpeed; TryDestoryLight(); Freezed = false; }

    }

    
    public void Slide()
    {
        Debug.Log("Slidiing");
        
        speed = startSpeed + ExtraSpeed;

    }

  
}
