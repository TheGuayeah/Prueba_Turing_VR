using System;
using UnityEngine;

public class InventoryVR : MonoBehaviour
{
   [SerializeField]
   private GameObject inventory;
   [SerializeField]
   private GameObject anchor;

   private bool isUIActive;

   private void Awake()
   {
      inventory.SetActive(false);
      isUIActive = false;
   }

   private void Start()
   {
      GameInput.Instance.OnPrimaryBtnAction += GameInput_OnPrimaryBtnAction;
   }

   private void GameInput_OnPrimaryBtnAction(object sender, EventArgs e)
   {
      isUIActive = !isUIActive;
      inventory.SetActive(isUIActive);
      anchor.SetActive(isUIActive);

      if(isUIActive)
      {
         inventory.transform.position = anchor.transform.position;
         inventory.transform.eulerAngles =
            new Vector3(
               anchor.transform.eulerAngles.x * 15,
               anchor.transform.eulerAngles.y,
               0
            );
      }
   }
}
