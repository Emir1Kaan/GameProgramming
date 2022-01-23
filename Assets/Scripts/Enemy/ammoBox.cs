
using UnityEngine;

public class ammoBox : MonoBehaviour
{
    [SerializeField]FireGun fireGun;
    private void Awake() {
        fireGun = GameObject.Find("Gun Hand").GetComponent<FireGun>();
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            fireGun.getAmmo();
            Debug.Log("ammo Box");
            Destroy(gameObject);
        }
        
    }
}
