using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventFreeze : MonoBehaviour
{
    public GameObject FreezeLight;
    public float TimeFreeze=5f;
    private float TimerFreeze=-1;
    
    public int TimeToOcurre;
    private GameObject[] MinionsOnScene;
    private float ActualTime;
    private bool HasOccurred;
    public AudioClip FreezeWindSound;

    void Start()
    {

        GameObject PlayerScript=GameObject.FindGameObjectWithTag("Player");
        //Generate when will it happen
        TimeToOcurre = Random.Range(15,(int)PlayerScript.GetComponent<Player>().GameInitialTime);

       
        HasOccurred = false;

        ActualTime = 0;
    }

    
    void Update()
    {

        ActualTime += Time.deltaTime;

        //Check to make the event
        if (ActualTime >= TimeToOcurre && !HasOccurred)
        {
            FreezeMinions();
            HasOccurred = true;
        }


    }



    public void FreezeMinions()
    {
       

        MinionsOnScene = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject Minion in MinionsOnScene)
        {
            Minion.GetComponent<Minions>().MakeSlow(0,TimeFreeze);

        }


        if (MinionsOnScene.Length != 0)
        {

            Instantiate(FreezeLight);

            GetComponent<AudioSource>().clip = FreezeWindSound;
            GetComponent<AudioSource>().Play();
        }
    }

}
