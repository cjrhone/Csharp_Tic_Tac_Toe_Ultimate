using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

   [SerializeField]
   private Slider slider;

   public int playerHealth {get; private set;}
   private int maxHealth;

   public void Initialize(int maximum){
       maxHealth = maximum;
       playerHealth = maxHealth;
       slider.maxValue = maxHealth;
       slider.value = playerHealth; 
       print("HealthBar.cs Initialized, max health: " + maxHealth);
   }

    // Returns the resulting remaining health of the player
    public int TakeDamage(int damage) // Will include TIME BONUS feature for extra damage in the near future
    {
        print("damage: " + damage);
        print("playerHealth: " + playerHealth);
        print("healthbar: " + this);
        playerHealth -= damage;
        slider.value = playerHealth; 
        return playerHealth;
    }

}
