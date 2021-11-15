using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    ControlValues controlValues;
    [SerializeField]
    float speed;
    [SerializeField]
    float sprintSpeedMultiplier;
    [SerializeField]
    float rollingForce;

    bool isRolling;
    bool isSprinting;
    bool isFirstRollingFrame;
    Vector2 inputMovement;

	void Update()
    {
		if (CanMove())
		{
            inputMovement = Vector2.ClampMagnitude(controlValues.movement, 1f) * speed * (isSprinting ? sprintSpeedMultiplier : 1); 
		}
    }

	void FixedUpdate()
	{
		if (CanMove())
		{
			rb.velocity = inputMovement; 
		}
		else
		{
			if (isFirstRollingFrame)
			{
				rb.AddForce(inputMovement.normalized * rollingForce);
			}
		}
	}

    bool CanMove()
	{
        return !isRolling;
	}

    public void Roll()
	{
        isRolling = true;
        isFirstRollingFrame = true;
	}

    public void EndRoll()
	{
        isRolling = false;
	}

    public void Sprint()
	{
        isSprinting = true;
	}

    public void EndSprint()
	{
        isSprinting = false;
	}
}
