using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEBUG_HUD : MonoBehaviour
{
    [SerializeField]GameObject player;
    [SerializeField]GameObject fireGun;
    [SerializeField]Level level;
    [SerializeField] Text Txt_playerVelocity;
    [SerializeField] Text Txt_playerHealth;
    [SerializeField] Text Txt_playerAmmo;
    [SerializeField] Text Txt_enemyCount;
    [SerializeField] Text Text_endLevel;
    
    private void Awake() {
        player = GameObject.Find("Player");
        
    }

    private void FixedUpdate() {
        playerVelocity(player);
        playerHealth(player);
        playerAmmo(fireGun);
        enemiesCount(level);
    }

    void playerVelocity(GameObject player)
    {
        Txt_playerVelocity.text = "Player Velocity : " + player.GetComponent<PlayerMovement>().rb.velocity.magnitude.ToString("0.00");
    }

    void playerHealth(GameObject fireGun)
    {
        Txt_playerHealth.text = "Player Health : " + player.GetComponent<objectHealth>().currentHealth.ToString();
    }
    
    void playerAmmo(GameObject fireGun)
    {
        Txt_playerAmmo.text = "Ammo : " + fireGun.GetComponent<FireGun>().currentGunAmmo.ToString()+ "/" + fireGun.GetComponent<FireGun>().maxAmmo.ToString() + " + " + fireGun.GetComponent<FireGun>().currentAmmo.ToString(); 
    }

    void enemiesCount(Level level)
    {
         Txt_enemyCount.text = "Enemy: " + level.enemiesCount.ToString();
         if(level.enemiesCount == 0)
         {
             Text_endLevel.text = "YOU WON";
         }
    }
}
