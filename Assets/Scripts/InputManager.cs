using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    PlayerController player;
    [SerializeField]
    StateMachine stateMachine;

    Vector2 leftStick;
    bool pressRoll;
    bool holdRoll;

    void Update()
    {
        leftStick = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		if (Input.GetButtonDown("Jump"))
		{
            pressRoll = true;
            holdRoll = true;
		}
        else if (Input.GetButtonUp("Jump"))
        {
            pressRoll = false;
            holdRoll = false;
        }
    }

    void SendInputs()
	{

	}
}
