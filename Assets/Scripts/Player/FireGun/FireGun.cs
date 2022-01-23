using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    
    private RaycastHit hit;
     public GameObject hitObject;
    [HideInInspector] public Vector3 hitPoint;
    [SerializeField] float rayDistance = 100f;
    [SerializeField] float fireRate = 0.4f;
    public float maxAmmo = 30;
    [SerializeField] float reloadTime;
    public float currentAmmo = 0;
    public float currentGunAmmo = 0;

    [SerializeField] Camera camera;
    [SerializeField] Transform gunPoint;
    [SerializeField] GameObject bulletPrefab;



    private float nextFire = 0.0f;
    


    private void Awake() {
        currentGunAmmo = maxAmmo;
    }
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
        reloadGun();
    }


    void fireGun()
    {
        if (Input.GetMouseButton(1) && Time.time > nextFire && currentGunAmmo >= 1)
        {
            nextFire = Time.time + fireRate;
            createBullet();
            currentGunAmmo -= 1;
        }
    }

    void reloadGun()
    {
        if(Input.GetKeyDown(KeyCode.R) && currentAmmo >0)
        {
            
            if(currentAmmo >= maxAmmo && currentGunAmmo != maxAmmo)
            {
                currentAmmo -= maxAmmo -currentGunAmmo;
                currentGunAmmo = maxAmmo;
                
                
            }
            else if(currentAmmo<=maxAmmo)
            {
                currentGunAmmo = currentAmmo;
                currentAmmo = 0;
            }
            
        }
    }
    void createBullet()
    {
        GameObject bullet;
        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
    }

    public void getAmmo()
    {
         float ammo = Random.Range(15,25);
        if((currentAmmo + ammo)>=500)
        {
            currentAmmo = 500;
        }
        else
        {
            currentAmmo = currentAmmo + ammo;
        }
    }

}
