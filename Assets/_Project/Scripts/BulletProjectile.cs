using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
   [SerializeField]
   private TrailRenderer trailRenderer;
   [SerializeField]
   private Transform bulletHitVfxPrefab;
   [SerializeField]
   private float moveSpeed = 200f;

   private Vector3 targetPosition;

   private void FixedUpdate()
   {      
      Ray ray = new Ray(transform.position, transform.forward);
      Physics.Raycast(ray, out RaycastHit hitInfo, float.MaxValue);

      targetPosition = hitInfo.point;

      float distanceBeforeMoving = Vector3.Distance(transform.position, targetPosition);

      transform.position += targetPosition * moveSpeed * Time.deltaTime;

      float distanceAfterMoving = Vector3.Distance(transform.position, targetPosition);

      if (distanceBeforeMoving < distanceAfterMoving)
      {
         transform.position = targetPosition;
         trailRenderer.transform.SetParent(null);
         Instantiate(bulletHitVfxPrefab, targetPosition, Quaternion.identity);

         hitInfo.transform.TryGetComponent(out HealthSystem enemyHealth);
         Destroy(gameObject);

         if (enemyHealth == null) return;
         enemyHealth.TakeDamage(30);
      }
   }
}
