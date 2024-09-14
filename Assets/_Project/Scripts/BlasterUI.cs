using System;
using TMPro;
using UnityEngine;

public class BlasterUI : MonoBehaviour
{
   [SerializeField]
   private ShootAction shootAction;
   [SerializeField]
   private TextMeshProUGUI ammoText;

   private void Start()
   {
      shootAction.OnShoot += ShootAction_OnShoot;
   }

   private void ShootAction_OnShoot(object sender, EventArgs e)
   {
      ammoText.text = shootAction.GetCurrentAmmo().ToString();
   }
}
