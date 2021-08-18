using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : Bullets
{

    public float Slow;
    public float SlowTime;

    // Start is called before the first frame update
    void Start()
    {

        Slow = .6f;
        SlowTime = 1.5f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Objective == null)
        {
            Destroy(gameObject);
            return;


        }

        Move();

        if (Vector3.Distance(transform.position, Objective.transform.position) <= .2)
        {
            MakeDmg();
            SlowEffect();
            return;
        }
    }

    //Extra method to apply Slowness
    public void SlowEffect()
    {

        Objective.GetComponent<Minions>().MakeSlow(Slow,SlowTime);

    }

}
