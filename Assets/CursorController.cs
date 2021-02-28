using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    private CameraControl controls;

    private void Awake()
    {
        controls = new CameraControl();
    }
}
