using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Towers : MonoBehaviour
{

    public float Range;
    public float Damage;
    public float TimeToFireRate;
    public float Health;
    public float StartHealth;
    public float MoneyValue;


    public GameObject Objective;
    private GameObject[] PossibleObjectives;
    private GameObject nearestObjective;
    private float ClosestDistance;

    public bool Freezed = false;
    public float TimeFreezed;
    public GameObject FreezeEffectPrefab;
    protected GameObject FreezingEffect;

    protected float shortestDistanceG;

    public Image healthbar;
    private GameObject PlayerManager;



    //Show Range while editing
    void OnDrawGizmosSelected()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);

    }

    //Goes trough each Enemy and compares the distance relative to the tower position
    //And ends up targeting the one closest to the tower
    //And it won´t change until it goes out of range or dies
    public void SearchNewObjective()
        {
            Debug.Log("Finding");
            PossibleObjectives = GameObject.FindGameObjectsWithTag("Enemy");
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

                //Send to son
                shortestDistanceG = shortestDistance;


                }

            }


              if(nearestObjective!=null && shortestDistance <= Range)
                {

                     Objective = nearestObjective;

                }else
                {
                    Objective = null;
                }

        }

    //The tower Taking damage
    //And gives money if it´s destroyed;
    public  void MakeDamage(float Damage)
    {

        Health -= Damage;

        healthbar.fillAmount = Health / StartHealth;

        if (Health <= 0)
        {
            PlayerManager = GameObject.FindGameObjectWithTag("Player");
            PlayerManager.GetComponent<Player>()._Coins+= (int) MoneyValue;
            PlayerManager.GetComponent<Player>().UpdateCoins();
            Destroy(gameObject);
            return;
        }


    }


}
