using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(CharacterController))]
public class CameraController : MonoBehaviour
{

    private CameraController controller;
    private Vector3 Camvelocity;
    private InputManager inputManager;

    [SerializeField]
    public int camSpeed = 1;



    
    private void Start()
    {
        controller = GetComponent<CameraController>();
        inputManager = InputManager.Instance;
    }




    private void Update()
    {
        Vector2 movement = inputManager.GetCameraMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);


        if(move != Vector3.zero)
        {
            gameObject.transform.forward = move; 
        }
    }
}
 