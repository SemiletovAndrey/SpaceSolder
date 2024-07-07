using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoysticForMovement : JoysticHandler
{
    [SerializeField] PlayerMovement playerMovement;

    private bool isMoving;
    private void FixedUpdate()
    {
        float inputMagnitude = inputVectorOutput.sqrMagnitude;
        if ((inputVectorOutput.x != 0 && inputMagnitude < 0.25f) || (inputVectorOutput.z != 0 && inputMagnitude < 0.25f))
        {
            playerMovement.RotateCharacterInPlace(new Vector3(inputVectorOutput.x, 0, inputVectorOutput.z));
            isMoving = false;
            playerMovement.PlayerControllerAnimation(isMoving);
        }
        else if (inputVectorOutput.x != 0  || inputVectorOutput.z != 0)
        {
            playerMovement.MoveCharacter(new Vector3(inputVectorOutput.x, 0, inputVectorOutput.z));
            playerMovement.RotateCharacter(new Vector3(inputVectorOutput.x, 0, inputVectorOutput.z));
            isMoving = true;
            playerMovement.PlayerControllerAnimation(isMoving);
        }
        else
        {
            isMoving = false;
        }
        if(!isMoving)
        {
            playerMovement.PlayerControllerAnimation(isMoving);
        }
    }
}
