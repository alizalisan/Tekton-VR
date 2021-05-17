using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreRaycast : MonoBehaviour {

    public bool isRaycastLocationValid(Vector2 sp,Camera eventCamera)
    {
        return false;
    }
}
