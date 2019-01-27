using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{

    public static float getMotionForward()
    {
        return Mathf.Clamp(Input.GetAxis("LeftStickY") + Input.GetAxisRaw("Vertical"), -1, 1);
    }

    public static float getMotionHorizontal()
    {
        return Mathf.Clamp(Input.GetAxis("LeftStickX") + Input.GetAxisRaw("Horizontal"), -1, 1);
    }

    public static float getCameraX()
    {
        return Mathf.Clamp(Input.GetAxis("RightStickX") + Input.GetAxis("Mouse X"), -1, 1);
    }

    public static float getCameraY()
    {
        return Mathf.Clamp(Input.GetAxis("RightStickY") + Input.GetAxis("Mouse Y"), -1, 1);
    }
}
