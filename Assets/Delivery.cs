using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroydDelay = 0.5f;

    bool hasPackage;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("You delivered the package.");
            hasPackage = false;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("You Picked up the package.");
            hasPackage = true;
            Destroy(collision.gameObject, destroydDelay);
        }
    }
}
 