using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMovement : MonoBehaviour
{
    [Header("ComboMovementDistances")]
    [SerializeField] float quarterSpeed = 0.25f;
    [SerializeField] float halfSpeed = 0.5f;
    [SerializeField] float normalSpeed = 1f;
    [SerializeField] float doubleSpeed = 2f;
    [SerializeField] float backwardsSpeed = -3f;
    [SerializeField] float doubleBackwardsSpeed = 6f;
    
    [SerializeField] float stopTime = 0.1f;
    [SerializeField] float longStopTime = 0.1f;

    //[SerializeField] ThirdPersonMovement thirdPersonMovement;

    public void QuarterSpeed()
    {
       // thirdPersonMovement.BurstForward(quarterSpeed,stopTime);
    }

    public void HalfSpeed()
    {
       // thirdPersonMovement.BurstForward(halfSpeed, stopTime);
    }

    public void NormalSpeed()
    {
       // thirdPersonMovement.BurstForward(normalSpeed, stopTime);
    }

    public void DoubleSpeed()
    {
       // thirdPersonMovement.BurstForward(doubleSpeed, stopTime);
    }

    public void longDoubleSpeed()
    {
       // thirdPersonMovement.BurstForward(doubleSpeed, longStopTime);
    }

    public void BackwardsSpeed()
    {
       // thirdPersonMovement.BurstForward(backwardsSpeed, stopTime);
    }

    public void DoubleBackwardsSpeed()
    {
       // thirdPersonMovement.BurstForward(doubleBackwardsSpeed, stopTime);
    }

   
}
