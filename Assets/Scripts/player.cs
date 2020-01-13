using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    //Variables

    // player
    public float movementSpeed;
    Animation anim;

    public float attackTimer;

    private bool moving;
    private bool attacking;
    private bool followingEnemy;

    // pmr
    public GameObject playerMovePoint;
    private Transform pmr;
    private bool triggeringPMR;

   

    // enemy 
    private bool triggeringEnemy;
    private GameObject attackingEnemy;





    //Functions
    void Start()
    {
        pmr = Instantiate(playerMovePoint.transform, this.transform.position, Quaternion.identity);
        pmr.GetComponent<BoxCollider>().enabled = false;
        anim = GetComponent<Animation>();
    }
    void Update()
    {
        //player mvt
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        float hitDistance = 0.0f;

        if (playerPlane.Raycast(ray, out hitDistance))
        {
            Vector3 mousePosition = ray.GetPoint(hitDistance);
            if (Input.GetMouseButtonDown(0))
            {
                moving = true;
                triggeringPMR = false;
                pmr.transform.position = mousePosition;
                pmr.GetComponent<BoxCollider>().enabled = true;

                if(Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "enemy")
                    {
                        attackingEnemy = hit.collider.gameObject;
                        followingEnemy = true;
                    }
                } else {
                    attackingEnemy = null;
                    followingEnemy = false;
                }
            }
        }
        if (moving)
            Move();
        else
        {
            if (attacking)
                Attack();
            else
                Idle();
            
        }

        if(triggeringPMR)
        {
            moving = false;
        }

        if(triggeringEnemy)
        {
            Attack();
        }
    }

    public void Idle()
    {
        anim.CrossFade("idle");
    }

    public void Move()
    {
        if(followingEnemy)
        {
            if( triggeringEnemy == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, attackingEnemy.transform.position, movementSpeed);
                this.transform.LookAt(attackingEnemy.transform);
            } else {
                Attack();
            }
        } else {
            transform.position = Vector3.MoveTowards(transform.position, pmr.transform.position, movementSpeed);
            this.transform.LookAt(pmr.transform);
        }

        anim.CrossFade("walk");
    }

    public void Attack()
    {
        anim.CrossFade("attack");
        transform.LookAt(attackingEnemy.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PMR")
        {
            triggeringPMR = true;
        }

        if(other.tag =="enemy")
        {
            triggeringEnemy = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "PMR")
        {
            triggeringPMR = false;
        }

        if (other.tag == "enemy")
        {
            triggeringEnemy = false;
        }
    }

}
