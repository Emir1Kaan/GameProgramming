using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed;
    

    private void Update() {
        bulletMovement();
    }

    void bulletMovement()
    {
        transform.position = transform.position + transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Obstacle")
        {
            Debug.Log("Bullet Hit : "+ other.gameObject.name);
            Destroy(gameObject);
        }
        
    }
}
