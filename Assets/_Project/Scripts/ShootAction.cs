using System;
using UnityEngine;

public class ShootAction : MonoBehaviour
{
   public event EventHandler OnShoot;
   public event EventHandler OnReload;

   [SerializeField]
   private Transform bulletPrefab;
   [SerializeField]
   Transform blasterSpawn;
   [SerializeField]
   private AudioSource shootSound, jammedSound, reloadSound;
   [SerializeField]
   private int maxAmmo = 5;
   [SerializeField]
   private int currentAmmo = 5;

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

   public void Reload()
   {
      if (currentAmmo == maxAmmo) return;

      reloadSound.Play();
      currentAmmo = maxAmmo;

      OnReload?.Invoke(this, EventArgs.Empty);
   }

   public int GetCurrentAmmo()
   {
      return currentAmmo;
   }
}
