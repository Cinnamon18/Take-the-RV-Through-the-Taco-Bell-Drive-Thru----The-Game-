using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static void ToggleControllerInputEnabled() {
        disableControllerInput = !disableControllerInput;
    }
    static bool disableControllerInput = false;

    public static float getMotionForward()
    {
        return Mathf.Clamp((disableControllerInput ? 0 : Input.GetAxis("LeftStickY")) + Input.GetAxisRaw("Vertical"), -1, 1);
    }

    public static float getMotionHorizontal()
    {
        return Mathf.Clamp((disableControllerInput ? 0 : Input.GetAxis("LeftStickX")) + Input.GetAxisRaw("Horizontal"), -1, 1);
    }

    public static float getCameraX()
    {
        return Mathf.Clamp((disableControllerInput ? 0 : Input.GetAxis("RightStickX")) + Input.GetAxis("Mouse X"), -1, 1);
    }

    public static float getCameraY()
    {
        return Mathf.Clamp((disableControllerInput ? 0 : Input.GetAxis("RightStickY")) + Input.GetAxis("Mouse Y"), -1, 1);
    }
}
