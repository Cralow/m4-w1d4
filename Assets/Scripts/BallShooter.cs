using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShooter : MonoBehaviour
{

    public GameObject spherePrefab;
    public float shpereForce;
    public float shpereRad;
    public float maxDistance = 100f;      
    public LayerMask allLayer;
    public LayerMask obstacolLayer;


    public void SpawnBullet(Ray ray)
    {    
        Vector3 spawnPos = ray.origin + ray.direction * (shpereRad + 0.3f);
        GameObject bullet = Instantiate(spherePrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        rb.AddForce(ray.direction * shpereForce, ForceMode.Impulse);

        Destroy(bullet, 5f);    
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.SphereCast(ray, 0.5f, out RaycastHit hitInfo, maxDistance, allLayer))
            {
                if (hitInfo.collider.gameObject.layer == 3)
                {
                    Debug.Log(" ");
                }
                else
                {
                    SpawnBullet(ray);
               

                }


            }

        }

        }
    }
