using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput>
{
    public delegate void OnBodyMovementHandler(Ray point);
    public static event OnBodyMovementHandler OnBodyMove;

    public delegate void OnBodyMovementAnimHandler(float value);
    public static event OnBodyMovementAnimHandler OnBodyMovementAnim;



    [HideInInspector] public bool IsGameStart = false;
    private void Update()
    {
        CheckTheGame();
        OnBodyMovement();
    }
    private void CheckTheGame()
    {
        if (Input.GetMouseButton(0) && FinishControl.GetInstance().isGameFinished==false)
        {
            OnBodyMovementAnim?.Invoke(1.0f);
            IsGameStart = true;
        }
    }

    public void OnBodyMovement()
    {
        OnBodyMove?.Invoke(GetMousePosition());
    }

    private Ray GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray mouseWorldPos = Camera.main.ScreenPointToRay(mousePos);
        return mouseWorldPos;
    }
}
