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

    Vector2 inputMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputMovement = Vector2.ClampMagnitude(inputMovement, 1f) * speed;
    }

	void FixedUpdate()
	{
        rb.velocity = inputMovement;
	}
}
