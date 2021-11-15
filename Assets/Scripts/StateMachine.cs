using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerState
{
    IDLE,
    RUN,
    SPRINT,
    ROLL,
}

public class StateMachine : MonoBehaviour
{
    PlayerState currentState;

	void Start()
	{
		OnStateEnter(PlayerState.IDLE);
	}

	void Update()
	{
        Debug.Log("StateMachine");
		OnStateUpdate(currentState);
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
		throw new NotImplementedException();
	}

	private void OnEnterRun()
	{
		throw new NotImplementedException();
	}

	private void OnEnterSprint()
	{
		throw new NotImplementedException();
	}

	private void OnEnterRoll()
	{
		throw new NotImplementedException();
	}
	#endregion

	#region ON STATE UPDATE
	private void OnUpdateIdle()
	{
		throw new NotImplementedException();
	}

	private void OnUpdateRun()
	{
		throw new NotImplementedException();
	}

	private void OnUpdateSprint()
	{
		throw new NotImplementedException();
	}

	private void OnUpdateRoll()
	{
		throw new NotImplementedException();
	}
	#endregion

	#region ON STATE EXIT
	private void OnExitIdle()
	{
		throw new NotImplementedException();
	}

	private void OnExitRun()
	{
		throw new NotImplementedException();
	}

	private void OnExitSprint()
	{
		throw new NotImplementedException();
	}

	private void OnExitRoll()
	{
		throw new NotImplementedException();
	}
	#endregion
}
