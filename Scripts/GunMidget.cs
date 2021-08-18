using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMidget : MonoBehaviour
{

    private int interval = 20;
    public GameObject prefabBullet;
    public GameObject RotationAxis;
    private float fireCountDown;
    public Transform Canon;
    public float Range;
    public float Damage;
    public float TimeToFireRate;

    private GameObject[] PossibleObjectives;
    public GameObject Objective;

    // Start is called before the first frame update
    void Start()
    {
        Range = 8;
        Damage = 10;
        TimeToFireRate = 1.5f;
    }

    // Update is called once per frame
    void Update()
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

            Shoot();

            fireCountDown = TimeToFireRate;
        }

        if (Objective != null)
        {
            fireCountDown -= Time.deltaTime;

            //We didn´t need the pistol to move as the other gameobjects
            //Vector3 dir = Objective.transform.position - transform.position;
            //Quaternion lookAt = Quaternion.LookRotation(dir);
            //Vector3 rotation = lookAt.eulerAngles;
            //RotationAxis.transform.rotation = Quaternion.Euler(rotation.x, rotation.y, 0f);
        }
    }
    //Show the range while editing
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, Range);

    }
    //Reused Function from tower but with a little change
    public void SearchNewObjective()
    {
        Debug.Log("Finding");
        PossibleObjectives = GameObject.FindGameObjectsWithTag("Turret");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestObjective = null;

        foreach (GameObject CurrentObjective in PossibleObjectives)
        {
            float distanceToObjective = Vector3.Distance(transform.position, CurrentObjective.transform.position);
            if (distanceToObjective < shortestDistance)
            {
                shortestDistance = distanceToObjective;
                Objective = CurrentObjective;
                nearestObjective = Objective;

                

            }

        }


        if (nearestObjective != null && shortestDistance <= Range)
        {

            Objective = nearestObjective;

        }
        else
        {
            Objective = null;
        }

    }

    //instantiate bullet
    public void Shoot()
    {

        GameObject Bullet = Instantiate(prefabBullet, Canon.transform.position, Canon.transform.rotation);
        Bullet.GetComponent<Bullets>().damagebullet = Damage;

        if (Bullet != null)
        {
            Bullet.GetComponent<Bullets>().BulletObjective(Objective);
        }


    }
}
