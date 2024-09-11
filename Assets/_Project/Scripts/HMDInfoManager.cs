using UnityEngine;
using UnityEngine.XR;

public class HMDInfoManager : MonoBehaviour
{


   private void Start()
   {
      Debug.Log("Is Device Active: " + XRSettings.isDeviceActive);
      Debug.Log("Device Name: " + XRSettings.loadedDeviceName);
      if (!XRSettings.isDeviceActive)
      {
         Debug.Log("No XR Device Detected");
      }
      else if (XRSettings.isDeviceActive &&
         (XRSettings.loadedDeviceName == "Mock HMD" ||
         XRSettings.loadedDeviceName == "MockHMDDisplay")
      )
      {

      }
   }
}
