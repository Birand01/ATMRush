using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _anim;

    private void OnEnable()
    {
        ConveyorStoppage.OnPlayerIdleState += MovementAnimation;
        PlayerInput.OnBodyMovementAnim += MovementAnimation;
    }
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }

    private void MovementAnimation(float value)
    {
        _anim.SetFloat("Speed",value);
    }
    private void OnDisable()
    {
        ConveyorStoppage.OnPlayerIdleState -= MovementAnimation;
        PlayerInput.OnBodyMovementAnim -= MovementAnimation;
    }

}
