using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{

    public float speed;
    public float damagebullet;
    protected GameObject Objective;

    public float RotationSpeed;
    private Quaternion _lookRotation;
    private Vector3 _direction;



    void Update()
    {
        //Check if the is still an Objective
        if (Objective == null)
        {
            Destroy(gameObject);
            return;


        }

        Move();

        if(Vector3.Distance(transform.position, Objective.transform.position)<=.2 )
        {
            MakeDmg();
            return;
        }

    }

    //Pass Objective from Turret to Bullet
    public void BulletObjective(GameObject _Objective)
    {
        Objective = _Objective;
    }

    //In charge of moving and making it face the target
    public void Move() { 
         transform.position = Vector3.MoveTowards(transform.position, Objective.transform.position, Time.deltaTime* speed);

       _direction = (Objective.transform.position - transform.position).normalized;    

       _lookRotation = Quaternion.LookRotation(_direction);

       transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime* RotationSpeed);
        }

    //Makes Damage to the target
    public void MakeDmg()
    {

        if (Objective.GetComponent<Minions>() != null) { Objective.GetComponent<Minions>().MakeDamage(damagebullet); }

        if (Objective.GetComponent<Towers>() != null) { Objective.GetComponent<Towers>().MakeDamage(damagebullet); }

        Destroy(gameObject);

        return;
    }

}
