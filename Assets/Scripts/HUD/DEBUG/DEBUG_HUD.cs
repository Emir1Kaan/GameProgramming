using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DEBUG_HUD : MonoBehaviour
{
    [SerializeField]GameObject player;
    [SerializeField] Text Txt_playerVelocity;
    
    private void Awake() {
        player = GameObject.Find("Player");
    }


    private void FixedUpdate() {
        playerVelocity(player);
    }

    void playerVelocity(GameObject player)
    {
        Txt_playerVelocity.text = "Player Velocity : " + player.GetComponent<PlayerMovement>().rb.velocity.magnitude.ToString("0.00");
    }
}
