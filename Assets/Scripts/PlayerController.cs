using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    float speed;
    [SerializeField]
    ControlValues controlValues;

    bool isRolling;
    bool isSprinting;
    Vector2 inputMovement;

    void Update()
    {
        Debug.Log("Player");
        inputMovement = Vector2.ClampMagnitude(controlValues.movement, 1f) * speed;
    }

	void FixedUpdate()
	{
        rb.velocity = inputMovement;
	}

    void Roll()
	{

	}

    void Sprint()
	{

	}
}
