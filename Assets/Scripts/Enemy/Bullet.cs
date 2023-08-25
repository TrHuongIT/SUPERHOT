using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Transform hitTrandorm = collision.transform;
        if (hitTrandorm.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTrandorm.GetComponent<PlayerHealth>().TakeDame(Random.Range(10,15));
        }
        Destroy(gameObject);
    }
}
