using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Quaternion actual;
    private float sum = 0;


    private Vector3 _speed;
    public int speed;



    // Start is called before the first frame update
    void Start()
    {
        //_direction = gobject.transform.position;



    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = transform.position + new Vector3(0f, 0f, 1f)*Time.deltaTime;
        //sum = (sum + 1) * Time.deltaTime;

        //transform.rotation = new Quaternion(0f, sum, 0f, 0f);

        _speed.x = 0;
        _speed.y = speed;
        _speed.z = 0;

        gameObject.transform.Rotate(_speed * Time.deltaTime);


        /* _direction = (gobject.transform.position - transform.position).normalized;

        _lookRotation = Quaternion.LookRotation(_direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * RotationSpeed);*/



        //transform.position = Vector3.MoveTowards(transform.position, NextPoint.position, Time.deltaTime * speed);
    }
}
