using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private Rigidbody enemyRb;
    private GameObject player;
    private PlayerController playerControllerScript;

    public float enemySpeed;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        playerControllerScript = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerControllerScript.isGameOver)
        {
            Vector3 moveDirection = player.transform.position - transform.position;
            enemyRb.AddForce(moveDirection.normalized * enemySpeed);
            transform.LookAt(moveDirection.normalized + new Vector3(0, transform.localScale.y / 2, 0), Vector3.up);
        }
        else if (playerControllerScript.isGameOver)
        {
            Debug.Log("Zombies Win!!!");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }

}
