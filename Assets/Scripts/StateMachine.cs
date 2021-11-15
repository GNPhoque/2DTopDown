using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

enum PlayerState
{
    IDLE,
    RUN,
    SPRINT,
    ROLL,
}

public class StateMachine : MonoBehaviour
{
	[SerializeField]
	PlayerController player;
	[SerializeField]
	ControlValues controlValues;
	[SerializeField]
	float rollTime;
	[SerializeField]
	TMP_Text text;

	float rollRemainingTime;
	PlayerState currentState;

	void Start()
	{
		OnStateEnter(PlayerState.IDLE);
	}

	void Update()
	{
		OnStateUpdate(currentState);
		Debug.Log(currentState);
		text.text = currentState.ToString();
	}

	void OnStateEnter(PlayerState state)
	{
		switch (state)
		{
			case PlayerState.IDLE:
				OnEnterIdle();
				break;
			case PlayerState.RUN:
				OnEnterRun();
				break;
			case PlayerState.SPRINT:
				OnEnterSprint();
				break;
			case PlayerState.ROLL:
				OnEnterRoll();
				break;
			default:
				Debug.LogError("OnStateEnter: Invalid state " + state.ToString());
				break;
		}
	}

	void OnStateExit(PlayerState state)
	{
		switch (state)
		{
			case PlayerState.IDLE:
				OnExitIdle();
				break;
			case PlayerState.RUN:
				OnExitRun();
				break;
			case PlayerState.SPRINT:
				OnExitSprint();
				break;
			case PlayerState.ROLL:
				OnExitRoll();
				break;
			default:
				Debug.LogError("OnStateExit: Invalid state " + state.ToString());
				break;
		}
	}

	void OnStateUpdate(PlayerState state)
	{
		switch (state)
		{
			case PlayerState.IDLE:
				OnUpdateIdle();
				break;
			case PlayerState.RUN:
				OnUpdateRun();
				break;
			case PlayerState.SPRINT:
				OnUpdateSprint();
				break;
			case PlayerState.ROLL:
				OnUpdateRoll();
				break;
			default:
				Debug.LogError("OnStateUpdate: Invalid state " + state.ToString());
				break;
		}
	}

	void TransitionToState(PlayerState newState)
	{
		OnStateExit(currentState);
		currentState = newState;
		OnStateEnter(newState);
	}

	#region ON STATE ENTER
	private void OnEnterIdle()
	{
	}

	private void OnEnterRun()
	{
	}

	private void OnEnterSprint()
	{
		player.Sprint();
	}

	private void OnEnterRoll()
	{
		player.Roll();
		rollRemainingTime = rollTime;
	}
	#endregion

	#region ON STATE UPDATE
	private void OnUpdateIdle()
	{
		if (controlValues.rollButtonDown)
		{
			TransitionToState(PlayerState.ROLL);
		}
		else if (controlValues.movement != Vector2.zero)
		{
			if (controlValues.roll)
			{
				TransitionToState(PlayerState.SPRINT);
			}
			else TransitionToState(PlayerState.RUN);
		}
	}

	private void OnUpdateRun()
	{
		if (controlValues.rollButtonDown)
		{
			TransitionToState(PlayerState.ROLL);
		}
		else if (controlValues.movement.magnitude == 0f)
		{
			TransitionToState(PlayerState.IDLE);
		}
	}

	private void OnUpdateSprint()
	{
		if (controlValues.movement.magnitude == 0f)
		{
			TransitionToState(PlayerState.IDLE);
		}
		else if (!controlValues.roll)
		{
			TransitionToState(PlayerState.RUN);
		}
	}

	private void OnUpdateRoll()
	{
		rollRemainingTime -= Time.deltaTime;
		if (rollRemainingTime <= 0f)
		{
			if (controlValues.movement.magnitude == 0f)
			{
				TransitionToState(PlayerState.IDLE);
			}
			else
			{
				if (controlValues.roll)
				{
					TransitionToState(PlayerState.SPRINT);
				}
				else TransitionToState(PlayerState.RUN);
			}
		}
	}
	#endregion

	#region ON STATE EXIT
	private void OnExitIdle()
	{
	}

	private void OnExitRun()
	{
	}

	private void OnExitSprint()
	{
		player.EndSprint();
	}

	private void OnExitRoll()
	{
		player.EndRoll();
	}
	#endregion
}
