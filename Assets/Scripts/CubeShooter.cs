using System.Collections;
using System.Collections.Generic;

using UnityEngine;



public class CubeShooter : MonoBehaviour
{
    public Camera cam;                 
    public GameObject bulletHole;      
    public float force = 50f;
    public LayerMask cubeLayerMask;

    void Awake()
    {
         cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)){ 

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, cubeLayerMask))
            {            
                Vector3 spawnPos = hit.point + hit.normal * 0.001f;

                Quaternion spawnRot = Quaternion.LookRotation(-hit.normal);    
                Instantiate(bulletHole, spawnPos, spawnRot, hit.transform);


                Rigidbody rb = hit.rigidbody;

               Vector3 impulseDir = -hit.normal;                          
              rb.AddForceAtPosition(impulseDir * force, hit.point, ForceMode.Impulse);
                
            }
        }
    }
}
