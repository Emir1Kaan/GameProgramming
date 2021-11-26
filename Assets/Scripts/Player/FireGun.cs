using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{
    // Start is called before the first frame update
    private RaycastHit hit;
    [HideInInspector]public GameObject hitObject;
    [HideInInspector]public Vector3 hitPoint;
    [SerializeField] float rayDistance = 100f;
    [SerializeField] Camera camera;

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, rayDistance))
        {
            hitObject = hit.transform.gameObject;
            hitPoint = hit.point;
        }
        else
        {
            hitObject = null;

        }
    }
}
