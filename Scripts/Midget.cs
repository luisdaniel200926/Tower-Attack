using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Midget : Minions
{

    void Start()
    {
        starthealth = 25;
        startSpeed = 1.5f;
        
        playerManager = GameObject.FindGameObjectWithTag("Player");

        speed = startSpeed;
        health = starthealth;
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

        if (timerSlow > 0) { timerSlow -= Time.deltaTime; }
        if (timerSlow <= 0) { speed = startSpeed; TryDestoryLight(); }
    }


   
}
