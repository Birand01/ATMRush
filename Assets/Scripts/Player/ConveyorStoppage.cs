using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorStoppage : MonoBehaviour
{
    public delegate void OnPlayerIdleStateHandler(float value);
    public static event OnPlayerIdleStateHandler OnPlayerIdleState;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Conveyor"))
        {
            OnPlayerIdleState?.Invoke(0.0f);
            PlayerInput.GetInstance().IsGameStart = false;
        }
    }
}
