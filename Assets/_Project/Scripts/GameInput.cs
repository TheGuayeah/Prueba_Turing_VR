using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : Singleton<GameInput>
{
   public event EventHandler OnGripActionStarted;
   public event EventHandler OnGripActionCanceled;
   public event EventHandler OnPrimaryBtnAction;
   public event EventHandler OnSecondaryBtnAction;

   private XRDeviceControllerControls inputActions;
   private bool isGripActionPerformed;
   private bool isGripActionCanceled;

   protected override void Awake()
   {
      base.Awake();

      inputActions = new();
      inputActions.Controller.Enable();
      inputActions.Controller.Grip.performed += Grip_performed;
      inputActions.Controller.Grip.canceled += Grip_canceled;
      inputActions.Controller.PrimaryButton.performed += PrimaryButton_performed;
      inputActions.Controller.SecondaryButton.performed += SecondaryButton_performed;
   }

   private void PrimaryButton_performed(InputAction.CallbackContext ctx)
   {
      OnPrimaryBtnAction?.Invoke(this, EventArgs.Empty);
   }

   private void SecondaryButton_performed(InputAction.CallbackContext context)
   {
      OnSecondaryBtnAction?.Invoke(this, EventArgs.Empty);
   }

   private void Grip_performed(InputAction.CallbackContext ctx)
   {
      isGripActionPerformed = true;
      isGripActionCanceled = false;
      OnGripActionStarted?.Invoke(this, EventArgs.Empty);
   }

   private void Grip_canceled(InputAction.CallbackContext ctx)
   {
      isGripActionPerformed = false;
      isGripActionCanceled = true;
      OnGripActionCanceled?.Invoke(this, EventArgs.Empty);
   }

   public bool IsGripActionPerformed()
   {
      return isGripActionPerformed;
   }

   public bool IsGripActionCanceled()
   {
      return isGripActionCanceled;
   }
}
