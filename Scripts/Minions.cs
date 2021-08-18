using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minions : MonoBehaviour
{

    public float starthealth;
    public float startSpeed;

    protected Transform NextPoint;
    protected int i;
    public float health;
    public float speed ;
    protected float timerSlow=0;
    public int cost;
    protected bool Freezed;


    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;

    public GameObject playerManager;

    public Image healthbar;
    private float AmountHealed;

    public GameObject HearthParticles;
    

    //Get´s the points from other script for the minions to follow
   public void FindNextPoint()
    {
        if (i >= PointsScript.Points.Length-1)
        {

            playerManager.GetComponent<Player>().EndReached();

            Destroy(gameObject);


            
            return;
        }

        i++;
        Debug.Log(i);
        NextPoint = PointsScript.Points[i];


    }

    public void Move()
    {

       transform.position = Vector3.MoveTowards(transform.position, NextPoint.position, Time.deltaTime*speed);

       _direction = (NextPoint.position - transform.position).normalized;    

       _lookRotation = Quaternion.LookRotation(_direction);

       transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);

    }


    public virtual void MakeDamage(float Damage)
    {

        health -= Damage;

        if (AmountHealed != 0)
        {
            healthbar.fillAmount = health / starthealth+AmountHealed;
        }
        else
        {
            healthbar.fillAmount = health / starthealth;
        }
        

        if (health <= 0)
        {
            Destroy(gameObject);
            return;
        }


    }

    public void MakeSlow(float Slow,float Time)
    {


        if (startSpeed - Slow > 0)
        {
            speed = startSpeed - Slow;
        }
        else { speed = .2f; }

        if (Slow == 0) { speed = 0; Freezed = true; }


        timerSlow = Time;
    }

    //To Delete the light generated after the event
    public void TryDestoryLight()
    {
        if (GameObject.FindGameObjectWithTag("Freeze") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Freeze"));
        }

    }


    public void MakeHeal(float AmountHeal)
    {

        health += AmountHeal;

       Instantiate(HearthParticles, transform);
        

        AmountHealed = AmountHeal;

    }

}
