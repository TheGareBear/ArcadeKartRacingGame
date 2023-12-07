using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    public float acceleration;
    public float turnSpeed;
    
    public Transform carModel;
    private Vector3 startModelOffset;

    public float groundCheckRate;
    private float lastGroundCheckTime;

    private float curYRot;

    private bool accelerateInput;
    private float turnInput;

    public Rigidbody rig;

    void Start()
    {
        startModelOffset = carModel.transform.localPosition;
    }

    void Update () {
        curYRot += turnInput * turnSpeed * Time.deltaTime;

        carModel.transform.position = transform.position + startModelOffset;
        carModel.transform.eulerAngles = new Vector3(0, curYRot, 0);
    }

    void FixedUpdate()
    {
        if(accelerateInput == true) {
            rig.AddForce(carModel.forward * acceleration, ForceMode.Acceleration);
        }    
    }

    public void OnAccelerateInput (InputAction.CallbackContext context) {
        if (context.phase == InputActionPhase.Performed) 
            accelerateInput = true;
        else
            accelerateInput = false;
    }

    public void OnTurnInput (InputAction.CallbackContext context) {
        turnInput = context.ReadValue<float>();
    }
}
