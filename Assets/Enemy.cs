using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health;

    public NavMeshAgent agent;

    public GameObject player;

    public bool objectPool;

    [HideInInspector]
    public int damageToPlayer;

    bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        damageToPlayer = 10;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            if(!objectPool)
            Destroy(gameObject);
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        agent.destination = player.transform.position;

    }

    public void TakeDamage(int damage)
    {
        Debug.Log(health);

        health -= damage;
    }
}