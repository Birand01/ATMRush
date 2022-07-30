using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/PlayerMovementData")]
public class PlayerMovementData : ScriptableObject
{
    public float swipeSpeed;
    public float currentSpeed;
    public float obstacledSpeed;
}
