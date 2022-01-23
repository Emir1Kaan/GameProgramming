using UnityEngine;

public class healthBox : MonoBehaviour
{
    objectHealth playerHealth;

    private void Awake() {
        playerHealth = GameObject.Find("Player").GetComponent<objectHealth>();

    }
   private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player")
        {
            playerHealth.getHeal();
            Debug.Log("heal Box");
            Destroy(gameObject);
            
        }
        
    }
}
