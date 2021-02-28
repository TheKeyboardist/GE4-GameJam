using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{


    private static InputManager _instance;


    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Start()
    {
        cameraControls.Mouse.Click.started += _ => StartedClick();
        cameraControls.Mouse.Click.performed += _ => EndedClick();
    }


    private void StartedClick()
    {

    }


    private void EndedClick()
    {
            
    }



    private CameraControl cameraControls;

    private void Awake()
    {
        if(_instance != null && _instance !=  this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        cameraControls = new CameraControl();
    }

    private void OnEnable()
    {
        cameraControls.Enable();
    }

    private void OnDesable()
    {
        cameraControls.Disable();
    }


    public Vector2 GetCameraMovement()
    {
        return cameraControls.Camera.Movement.ReadValue<Vector2>();
    }




}
