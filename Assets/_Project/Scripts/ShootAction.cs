using System;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
   public event EventHandler OnShoot;

   [SerializeField]
   private Transform bulletPrefab;
   [SerializeField]
   private AudioSource shootSound, jammedSound;
   [SerializeField]
   private int maxAmmo = 5;
   [SerializeField]
   private int currentAmmo = 5;

   private void Start()
   {
      GameInput.Instance.OnSecondaryBtnAction += GameInput_OnSecondaryBtnAction;
   }

   private void GameInput_OnSecondaryBtnAction(object sender, EventArgs e)
   {
      Reload();
   }

   public void TakeAction(Transform bulletParent)
   {
      if (currentAmmo <= 0)
      {
         jammedSound.Play();
         return;
      }

      Transform bullet = Instantiate(
         bulletPrefab, 
         bulletParent.position, 
         bulletParent.rotation
      );
      bullet.SetParent(bulletParent);
      shootSound.Play();
      currentAmmo--;

      OnShoot?.Invoke(this, EventArgs.Empty);
   }

   private void Reload()
   {
      currentAmmo = maxAmmo;
   }

   public int GetCurrentAmmo()
   {
      return currentAmmo;
   }
}
