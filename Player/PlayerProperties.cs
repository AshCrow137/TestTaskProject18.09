using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties :MonoBehaviour
{
    [SerializeField]
    private int points = 0;
    [SerializeField]
    private List<GameObject> playerBodies = new List<GameObject>();
    private int activeBodyIndex = 0;

    private int pointsMultiplyer = 1;

    public static PlayerProperties Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);

        }
        else
        {
            Instance = this;
        }
        GlobalEventManager.PickUpEvent.AddListener(AddPoints);
        GlobalEventManager.FinishEvent.AddListener(CountFinalPoints);
    }
    public int GetPoints()
    {
           return points;
    }
    private void AddPoints(int amount)
    {
        points += amount;
        CheckPoints();

    }
    private void CountFinalPoints()
    {
        points *= pointsMultiplyer;
    }
    public void setMultiplayer(int value)
    {
        if(pointsMultiplyer<value)
        {
            pointsMultiplyer = value;
        }
        
    }
    private void CheckPoints()
    {
        int newBodyIndex = 0;
        if(points<=0)
        {
            //Lose
            return;
        }
        else if(points>0 && points <40)
        {
            newBodyIndex = 0;
        }
        else if(points>=40 && points<70)
        {
            newBodyIndex = 1;
        }
        else if (points >= 70 && points < 100)
        {
            newBodyIndex = 2;
        }
        else if (points >= 100 && points < 150)
        {
            newBodyIndex = 3;
        }
        else
        {
            newBodyIndex = activeBodyIndex;
        }

        if(newBodyIndex != activeBodyIndex)
        {
            
            playerBodies[activeBodyIndex].SetActive(false);
            playerBodies[newBodyIndex].SetActive(true);
            activeBodyIndex = newBodyIndex;
        }
    }
}
