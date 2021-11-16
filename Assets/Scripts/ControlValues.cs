using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ControlValues : ScriptableObject
{
	public Vector2 movement;
	public Vector2 direction;

	public bool roll;
	public bool rollButtonDown;
}
