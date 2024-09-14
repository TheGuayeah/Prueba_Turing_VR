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
   }

   private void HealthSystem_OnTakeDamage(object sender, EventArgs e)
   {
      healthBarImage.fillAmount = healthSystem.GetHealthNormalized();
   }
}
