using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
   [SerializeField]
   private Image slotImage;

   private GameObject itemInSlot;
   private Color originalColor;

   private void Start()
   {
      originalColor = slotImage.color;
   }

   private void OnTriggerStay(Collider other)
   {
      if (itemInSlot != null) return;

      GameObject itemObject = other.gameObject;

      if (!IsItem(itemObject, out Item item)) return;

      if (GameInput.Instance.IsGripActionCanceled())
      {
         InsertItem(item);
      }
   }

   private void OnTriggerExit(Collider other)
   {
      GameObject itemObject = other.gameObject;

      if (!IsItem(itemObject, out Item item)) return;

      if (GameInput.Instance.IsGripActionPerformed())
      {
         Debug.Log("Grip Action Performed");
         if (!item.IsInSlot(out Slot slot)) return;
         GrabItemFromSlot(item, slot);
      }
   }

   private bool IsItem(GameObject itemObject, out Item item)
   {
      itemObject.TryGetComponent<Item>(out item);
      return item != null;
   }

   private void GrabItemFromSlot(Item item, Slot slot)
   {
      slot.itemInSlot = null;
      slot.ResetColor();
      item.SetUp();
   }

   private void InsertItem(Item item)
   {
      if (itemInSlot != null) return;

      item.Store(this);
      itemInSlot = item.gameObject;
      slotImage.color = Color.grey;
   }

   public void ResetColor()
   {
      slotImage.color = originalColor;
   }
}
