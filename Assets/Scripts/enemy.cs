using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //variables
    public float enemyHealth;
    private float health;
    public float movementSpeed;

    private GameObject player;

    private bool triggeringPlayer;
    public bool aggro;

    public float attackTimer;
    private float _attackTimer;

    //functions
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if(aggro)
        {
            FollowPlayer();
        }


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            triggeringPlayer = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            triggeringPlayer = false;
        }

    }

    public void Attack()
    {

    }

    public void FollowPlayer()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed);
    }
}
