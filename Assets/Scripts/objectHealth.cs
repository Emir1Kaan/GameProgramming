using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectHealth : MonoBehaviour
{

    [SerializeField] GameObject healthBox;
    [SerializeField] GameObject ammoBox;

    [SerializeField] Transform itemDropPos;

    
    [SerializeField] float maxHealth = 100f;
     public float currentHealth = 100f;
    // Start is called before the first frame update
    private void Start() {
        currentHealth = maxHealth;
    }
    public void getDamage(float bulletDamage)
    {
        currentHealth -= bulletDamage;
        if (Die(currentHealth))
        {
            if (gameObject.tag != "Player")
            {
                DropItem();
                Destroy(gameObject);
            }
            else
            {
                PlayerDie();
            }
        }
    }
    bool Die(float objectHealth)
    {
        if (objectHealth <= 0)
        {
            return true;

        }
        else
        {
            return false;
        }

    }

    void DropItem()
    {
        if (Random.Range(0, 10) > 5)
        {
            Instantiate(ammoBox, itemDropPos.position, transform.rotation);
            Debug.Log("Dropped Ammo Box");
        }
        else
        {
            Instantiate(healthBox, itemDropPos.position, transform.rotation);
            Debug.Log("Dropped Health Box");
        }

    }

    void PlayerDie()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.transform.localScale = new Vector3(1, 0.5f, 1);
        Debug.Log("player died");
    }

    public void getHeal()
    {
        float heal = Random.Range(15,25);
        if((currentHealth + heal)>=maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth = currentHealth + heal;
        }
    }
}
