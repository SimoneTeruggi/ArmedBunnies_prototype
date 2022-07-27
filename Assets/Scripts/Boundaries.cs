using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("EnemyBig") || collision.transform.CompareTag("EnemyMed"))
        {
            Destroy(collision.gameObject);
        }
    }
}
