using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    ControlValues controlValues;

    void Update()
    {
        controlValues.movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (controlValues.movement != Vector2.zero)
        {
            controlValues.direction = controlValues.movement.normalized;
        }
        if (Input.GetButtonDown("Jump"))
		{
            controlValues.roll = true;
            controlValues.rollButtonDown = true;
		}
        else if (Input.GetButton("Jump"))
        {
            controlValues.roll = true;
            controlValues.rollButtonDown = false;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            controlValues.roll = false;
            controlValues.rollButtonDown = false;
        }
    }
}
