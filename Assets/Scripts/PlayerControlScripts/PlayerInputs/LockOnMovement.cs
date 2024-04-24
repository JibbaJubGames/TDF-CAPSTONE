using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnMovement : MonoBehaviour
{
    private Animator movementAnim;
    private LockOnSystem lockSystem;
    // Start is called before the first frame update
    void Start()
    {
        movementAnim = GetComponent<Animator>();
        lockSystem = GetComponentInParent<LockOnSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        SetLockMovementSystem();
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        StrafeLeftRight(horizontal);
        StrafeBack(vertical);
    }

    private void StrafeBack(float vertical)
    {
        if (vertical < 0 && lockSystem.lockedOn == true)
        {
            movementAnim.SetBool("LockBackStep", true);
        }
        else
        {
            movementAnim.SetBool("LockBackStep", false);
        }
    }

    private void StrafeLeftRight(float horizontal)
    {
        if (horizontal < 0 && lockSystem.lockedOn == true)
        {
            movementAnim.SetBool("StrafeLeft", true);
        }
        else
        {
            movementAnim.SetBool("StrafeLeft", false);
        }
        if (horizontal > 0 && lockSystem.lockedOn == true)
        {
            movementAnim.SetBool("StrafeRight", true);
        }
        else
        {
            movementAnim.SetBool("StrafeRight", false);
        }
    }

    private void SetLockMovementSystem()
    {
        if (lockSystem.lockedOn == true)
        {
            movementAnim.SetBool("LockedOn", true);
        }
        else
        {
            movementAnim.SetBool("LockedOn", false);
        }
    }
}
