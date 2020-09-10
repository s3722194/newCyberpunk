using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    [SerializeField]
    private int starting_Health_Points = 5;

    private int current_Health_Points;
    
    void onEnable()
    {
        current_Health_Points = starting_Health_Points;
    }

    public void TakeDamage(int damage)
    {
        current_Health_Points -= damage;

        if (current_Health_Points <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        gameObject.SetActive(false);
    }
}
