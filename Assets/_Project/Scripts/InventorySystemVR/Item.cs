using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
   private bool isInSlot;
   private Slot currentSlot;

   public Vector3 slotRotation = Vector3.zero;

   private void Update()
   {
      if (!isInSlot)
      {
         SetUp();
      }
   }

   public bool IsInSlot(out Slot slot)
   {
      slot = currentSlot;
      return isInSlot;
   }

   public void SetUp()
   {
      Rigidbody rigidBody = GetComponent<Rigidbody>();
      rigidBody.useGravity = true;
      rigidBody.isKinematic = false;
      isInSlot = false;
      currentSlot = null;
      transform.SetParent(null);
   }

   public void Store(Slot slot)
   {
      Rigidbody rigidBody = GetComponent<Rigidbody>();
      rigidBody.useGravity = false;
      rigidBody.isKinematic = true;
      transform.SetParent(slot.transform, true);
      currentSlot = slot;
      isInSlot = true;
      transform.localPosition = Vector3.zero;
      transform.localEulerAngles = slotRotation;
   }
}
