using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroydDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(30, 219, 20, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);

    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("You delivered the package.");
            hasPackage = false;
            spriteRenderer.color = noPackageColor; 
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("You Picked up the package.");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(collision.gameObject, destroydDelay);   
        }
    }
}
 