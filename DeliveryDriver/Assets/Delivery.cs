using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    
    [SerializeField] Color32 NoPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.25f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {

        Debug.Log("ouch! Slowed!");

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if(hasPackage && other.tag == "Customer")
        {
            Debug.Log("Delivered package!");
            hasPackage = false;
            spriteRenderer.color = NoPackageColor;
        }
        

    }
}
