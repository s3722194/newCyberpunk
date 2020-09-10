using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private Transform shoot_Point;

    [SerializeField]
    [Range(1, 5)]
    private int damage = 1;

    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float shoot_Rate = 1f;

    private float shoot_Timer;

    

    // Update is called once per frame
    void Update()
    {
        shoot_Timer += Time.deltaTime;

        if (shoot_Timer >= shoot_Rate)
        {
            if (Input.GetButton("Fire1"))
            {
                shoot_Timer = 0f;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Debug.DrawRay(shoot_Point.position
            , shoot_Point.forward * 100, Color.red, 2f);

        Ray ray = new Ray(shoot_Point.position, shoot_Point.forward);
        RaycastHit hit_Information;

        if (Physics.Raycast(ray, out hit_Information, 100))
        {
            var health_Points = hit_Information.collider.GetComponent<HealthPoints>();
            if (health_Points != null)
            {
                health_Points.TakeDamage(damage);
            }
        }

    }

}
