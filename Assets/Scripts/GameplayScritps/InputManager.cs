using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    public GameObject triesText;
    private Text tries;


    int numberOfTries = 5;

    private static InputManager _instance;
    private Camera mainCamera;

    public static InputManager Instance
    {
        get
        {
            return _instance;
        }
    }




    private void Start()
    {
        tries = triesText.GetComponent<Text>();
        tries.text = "Tries: " + numberOfTries;
        cameraControls.Mouse.Click.started += _ => StartedClick();
        cameraControls.Mouse.Click.performed += _ => EndedClick();
    }


    private void StartedClick()
    {

    }


    private void EndedClick()
    {
        DetectObject();
    }



    private void DetectObject()
    {
        Ray ray = mainCamera.ScreenPointToRay(cameraControls.Mouse.Position.ReadValue<Vector2>());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null)
            {
               if(hit.collider.gameObject.tag == "Treasure" && numberOfTries > 0)
               {
                    SceneManager.LoadScene("Win");
               }
               else if(numberOfTries > 0)
               {
                    Destroy(hit.collider.gameObject);
                    numberOfTries--;
                    if(numberOfTries == 0)
                    {
                        SceneManager.LoadScene("Lose");
                    }
                }
               
            }
        }
    }



    private CameraControl cameraControls;

    private void Awake()
    {
        mainCamera = Camera.main;
        if (_instance != null && _instance !=  this)
        {
            //Destroy(this.gameObject);
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


    private void Update()
    {
        tries.text = "Tries: " + numberOfTries;
    }

}
