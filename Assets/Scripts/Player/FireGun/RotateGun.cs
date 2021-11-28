using UnityEngine;

public class RotateGun : MonoBehaviour {

    public FireGun FireGun;

    private Quaternion desiredRotation;
    [SerializeField] private float rotationSpeed = 5f;

    void Update() {
        if (FireGun.hitObject == null) {
            desiredRotation = transform.parent.rotation;
        }
        else if(FireGun.hitObject != null && FireGun.hitObject.tag != "Player")
        {
            desiredRotation = Quaternion.LookRotation(FireGun.hitPoint - transform.position);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
    }

}
