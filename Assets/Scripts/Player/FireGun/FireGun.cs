using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    [HideInInspector] public GameObject hitObject;
    [HideInInspector] public Vector3 hitPoint;
    [SerializeField] float rayDistance = 100f;
    [SerializeField] float fireRate = 0.4f;
    [SerializeField] Camera camera;
    [SerializeField] Transform gunPoint;
    [SerializeField] GameObject bulletPrefab;



    private float nextFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rayDistance))
        {
            hitObject = hit.transform.gameObject;
            hitPoint = hit.point;
        }
        else
        {
            hitObject = null;

        }

        //Functions
        fireGun();
    }


    void fireGun()
    {
        if (Input.GetMouseButton(1) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            createBullet();
        }
    }

    void createBullet()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

}
