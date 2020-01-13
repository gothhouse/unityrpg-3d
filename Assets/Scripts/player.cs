using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //Variables
    public float movementSpeed;

    public GameObject playerMovePoint;
    private Transform pmr;
    private GameObject triggeringPMR;

    private bool moving;

    Animation anim;

    //Functions
    void Start()
    {
        pmr = Instantiate(playerMovePoint.transform, this.transform.position, Quaternion.identity);
        anim = GetComponent<Animation>();
    }
    void Update()
    {
        //player mvt
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDistance = 0.0f;

        if (playerPlane.Raycast(ray, out hitDistance))
        {
            Vector3 mousePosition = ray.GetPoint(hitDistance);
            if (Input.GetMouseButtonDown(0))
            {
                moving = true;
                pmr.transform.position = mousePosition;
            }
        }
        if (moving)
        {
            Move();
        }
    }

    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, pmr.transform.position, movementSpeed);
        this.transform.LookAt(pmr.transform);

        anim.CrossFade("walk");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PMR")
        {
            triggeringPMR = other.gameObject;
        }
    }
}
