using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
   [SerializeField]
   private HealthSystem healthSystem;
   [SerializeField]
   private Image healthBarImage;

   void Start()
   {
      healthSystem.OnTakeDamage += HealthSystem_OnTakeDamage;
      healthSystem.OnHeal += HealthSystem_OnHeal;
   }

   private void HealthSystem_OnTakeDamage(object sender, EventArgs e)
   {
      healthBarImage.fillAmount = healthSystem.GetHealthNormalized();
   }

   private void HealthSystem_OnHeal(object sender, EventArgs e)
   {
      healthBarImage.fillAmount = healthSystem.GetHealthNormalized();
   }
}
