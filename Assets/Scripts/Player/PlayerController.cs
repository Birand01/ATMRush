using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] public Vector2 clampValuesX = new Vector2(-8.35f, +8.35f);
    private Vector3 mouseStartPos, PlayerStartPos;
    public PlayerMovementData playerMovement;

    private void OnEnable()
    {
        PlayerInput.OnBodyMove += MovePlayer;
    }

    private void MovePlayer(Ray pointerPosition)
    {
        if (PlayerInput.GetInstance().IsGameStart)
        {

            var plane = new Plane(Vector3.up, 0.0f);
            float distance;

            if (plane.Raycast(pointerPosition, out distance))
            {
                Vector3 mousePos = pointerPosition.GetPoint(distance);
                Vector3 desiredPos = mousePos - mouseStartPos;
                Vector3 move = PlayerStartPos + desiredPos;
                move.x = Mathf.Clamp(move.x, clampValuesX.x, clampValuesX.y);
                move.z = -7.0f;
                Vector3 player = transform.position;
                player = new Vector3(Mathf.Lerp(player.x, move.x, Time.deltaTime * playerMovement.swipeSpeed), player.y, player.z);
                transform.position = player;
                transform.Translate(Vector3.forward * Time.deltaTime * playerMovement.currentSpeed);
            }
        }
    }
    private void OnDisable()
    {
        PlayerInput.OnBodyMove -= MovePlayer;
    }
}
