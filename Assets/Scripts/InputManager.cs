using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    ControlValues controlValues;

    void Update()
    {
        Debug.Log("Input");
        controlValues.movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (Input.GetButtonDown("Jump"))
		{
            controlValues.roll = true;
		}
        else if (Input.GetButtonUp("Jump"))
        {
            controlValues.roll = false;
        }
    }
}
