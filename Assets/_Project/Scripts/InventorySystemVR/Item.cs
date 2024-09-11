using UnityEngine;

public class Item : MonoBehaviour
{
   private bool isInSlot;
   private Slot currentSlot;

   public Vector3 slotRotation = Vector3.zero;

   public void SetSlot(Slot slot)
   {
      currentSlot = slot;
      isInSlot = true;
   }

   public bool IsInSlot(out Slot slot)
   {
      slot = currentSlot;
      return isInSlot;
   }

   public Slot GetCurrentSlot()
   {
      return currentSlot;
   }

   public void ClearCurrentSlot()
   {
      isInSlot = false;
      currentSlot = null;
   }

   public void ResetRigidbody()
   {
      Rigidbody rigidBody = GetComponent<Rigidbody>();
      rigidBody.isKinematic = !rigidBody.isKinematic;
      rigidBody.useGravity = !rigidBody.isKinematic;
   }
}
