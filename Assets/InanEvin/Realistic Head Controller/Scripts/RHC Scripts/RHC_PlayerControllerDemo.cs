using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class RHC_PlayerControllerDemo : MonoBehaviour
{

    [Header("Movement")]
    public float f_WalkSpeed;
    public float f_RunSpeed;
    private float f_UsedSpeed;
    public float f_JumpSpeed;
    public float f_Gravity;
    public string s_StandKey;
    private float f_StandHeight;
    public string s_CrouchKey;
    public float f_CrouchHeight;
    public float f_CrouchSpeedMultiplier;
    public string s_ProneKey;
    public float f_CrawlHeight;
    public float f_CrawlSpeedMultiplier;
    public float f_HeightChangeSpeed;
    private float f_SpeedMultiplier = 1.0f;
    private Coroutine co_HeightChange;
    private Vector3 v3_MoveDir;
    private bool b_RunToggle;
    private CharacterController cc_This;

    private void Awake()
    {
        cc_This = GetComponent<CharacterController>();
        f_UsedSpeed = f_RunSpeed;
        f_StandHeight = cc_This.height;
    }
    private void Start()
    {
        RHC_EventManager.PSVO_ChangeMovementState(RHC_EventManager.MovementState.Running);
    }

    private void Update()
    {
        if (cc_This.isGrounded)
        {
            if (RHC_EventManager.en_CurrentStanceState == RHC_EventManager.StanceState.OnAir)
                RHC_EventManager.PSVO_ChangeStanceState(RHC_EventManager.StanceState.Standing);
            v3_MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            v3_MoveDir = transform.TransformDirection(v3_MoveDir);
            v3_MoveDir *= f_UsedSpeed * f_SpeedMultiplier;

            if (cc_This.velocity.magnitude > 0.1f)
            {
                RHC_EventManager.PSVO_ChangeMovementState(RHC_EventManager.MovementState.Running);
            }

            if (cc_This.velocity.magnitude < 0.1f && RHC_EventManager.en_CurrentMovementState != RHC_EventManager.MovementState.Idling)
                RHC_EventManager.PSVO_ChangeMovementState(RHC_EventManager.MovementState.Idling);


        }

        v3_MoveDir.y -= Time.deltaTime * f_Gravity;
        cc_This.Move(v3_MoveDir * Time.deltaTime);
    }
}
