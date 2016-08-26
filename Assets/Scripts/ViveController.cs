using UnityEngine;
using System.Collections;

public class ViveController : MonoBehaviour {

    public Material[] matArray;

    private Material mat;
    private Renderer rend;
    private int index = 0;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        var left = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Leftmost);
        var right = SteamVR_Controller.GetDeviceIndex(SteamVR_Controller.DeviceRelation.Rightmost);
        if (left != -1 && SteamVR_Controller.Input(left).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("trigger left");
            SteamVR_Controller.Input(left).TriggerHapticPulse(1000);
            index++;
        } else if (right != -1 && SteamVR_Controller.Input(right).GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("trigger right");
            SteamVR_Controller.Input(right).TriggerHapticPulse(1000);
            index--;
        }

        if (rend != null)
        {
            rend.material = matArray[Mathf.Abs(index) % matArray.Length];
        }

    }
}
