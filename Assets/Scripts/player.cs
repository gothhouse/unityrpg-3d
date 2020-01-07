using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //Variables
    public float movementSpeed;
    public GameObject playerMovePoint;
    private Transform pmr;
    private bool pmrSpawned;


    //Functions
   void Update()
   {
        //player mvt
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDistance = 0.0f;

        if(playerPlane.Raycast(ray, out hitDistance))
        {
            Vector3 mousePosition = ray.GetPoint(hitDistance);
            if(Input.GetMouseButtonDown(0))
            {
                if(pmrSpawned)
                {
                    pmr = null;
                    pmr = Instantiate(playerMovePoint.transform, mousePosition, Quaternion.identity);
                } else {
                    pmr = Instantiate(playerMovePoint.transform, mousePosition, Quaternion.identity);
                }
                transform.position = Vector3.MoveTowards(transform.position, pmr.transform.position, 10f);
            }
        }
        if (pmr)
            pmrSpawned = true;
        else
            pmrSpawned = false;
   }
}
