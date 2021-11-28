using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    [SerializeField] float bulletDamage = 10f;
    [SerializeField] LayerMask hitLayer;
    

    private void Update() {
        bulletMovement();
    }

    void bulletMovement()
    {
        transform.position = transform.position + transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
       
        if(hitLayer == (hitLayer | (1 << other.gameObject.layer)))
        {
            Debug.Log("Bullet Hit : "+ other.gameObject.name);
            if(other.GetComponent<objectHealth>())
            {
                other.GetComponent<objectHealth>().getDamage(bulletDamage);
                
            }
            Destroy(gameObject);
        }
        
    }
}
