using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{

    public static Transform[] Points;

    // We used awake, cause sometime with start the minions wouldn´t work
    void Awake()
    {
        Points = new Transform[transform.childCount];

        for (int i = 0; i < Points.Length; i++)
        {
           Points[i]= transform.GetChild(i);
        }

    }

  
}
