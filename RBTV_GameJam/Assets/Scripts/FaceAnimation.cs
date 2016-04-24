using UnityEngine;
using System.Collections;

public class FaceAnimation : MonoBehaviour {


    public PlatformerMotor2D _motor;
    public Animator _faceAnimator;
    public Animator _bodyAnimator;
    private bool _isJumping;
    private bool _currentFacingLeft;
    public GameObject visualChild;
    public PlayerController controller;
    private bool throwDone =true;

    // Use this for initialization
    void Start()
    {
        //_motor = GetComponent<PlatformerMotor2D>();
        _faceAnimator.Play("HeadIdle");
        _bodyAnimator.Play("BodyIdle");
        _motor.onJump += SetCurrentFacingLeft;
        controller = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_motor.motorState == PlatformerMotor2D.MotorState.Jumping ||
            _isJumping &&
            (_motor.motorState == PlatformerMotor2D.MotorState.Falling ||
             _motor.motorState == PlatformerMotor2D.MotorState.FallingFast))
        {
            _isJumping = true;
            _faceAnimator.Play("HeadJump");
            _bodyAnimator.Play("BodyJump");

            if (_motor.velocity.x <= -0.1f)
            {
                _currentFacingLeft = true;
            }
            else if (_motor.velocity.x >= 0.1f)
            {
                _currentFacingLeft = false;
            }

        }
        else
        {
            _isJumping = false;

            if (_motor.motorState == PlatformerMotor2D.MotorState.Falling ||
                _motor.motorState == PlatformerMotor2D.MotorState.FallingFast)
            {
                _faceAnimator.Play("HeadFall");
                _bodyAnimator.Play("BodyDash");
            }
            else if (_motor.motorState == PlatformerMotor2D.MotorState.WallSliding ||
                     _motor.motorState == PlatformerMotor2D.MotorState.WallSticking)
            {
                _faceAnimator.Play("HeadClimb");
                _bodyAnimator.Play("BodyClimb");
            }
            else if (_motor.motorState == PlatformerMotor2D.MotorState.OnCorner)
            {
                _faceAnimator.Play("HeadClimb");
                _bodyAnimator.Play("BodyClimb");
            }
            else if (_motor.motorState == PlatformerMotor2D.MotorState.Slipping)
            {
                _faceAnimator.Play("HeadIdle");
                _bodyAnimator.Play("BodyClimb");
            }
            else if (_motor.motorState == PlatformerMotor2D.MotorState.Dashing)
            {
                _faceAnimator.Play("HeadRun");
                _bodyAnimator.Play("BodyDash");
            }
            else if (Input.GetButtonDown(controller.currentPlayerPrefix + PC2D.Input.THROW))
            {
                _bodyAnimator.Play("BodyAttack");
                _faceAnimator.Play("HeadThrow");
                throwDone = false;
                Invoke("ResetThrow",0.2f);
            }
            else if(throwDone)
            {
                if (_motor.velocity.sqrMagnitude >= 0.1f*0.1f)
                {
                    _bodyAnimator.Play("BodyRun");
                    _faceAnimator.Play("HeadRun");

                }
                else
                {
                    _faceAnimator.Play("HeadIdle");
                    _bodyAnimator.Play("BodyIdle");
                }
            }
        }

        // Facing
        float valueCheck = _motor.normalizedXMovement;

        if (_motor.motorState == PlatformerMotor2D.MotorState.Slipping ||
            _motor.motorState == PlatformerMotor2D.MotorState.Dashing ||
            _motor.motorState == PlatformerMotor2D.MotorState.Jumping)
        {
            valueCheck = _motor.velocity.x;
        }

        if (Mathf.Abs(valueCheck) >= 0.1f)
        {
            Vector3 newScale = visualChild.transform.localScale;
            newScale.x = Mathf.Abs(newScale.x) * ((valueCheck > 0) ? 1.0f : -1.0f);
            visualChild.transform.localScale = newScale;
        }
    }

    private void SetCurrentFacingLeft()
    {
        _currentFacingLeft = _motor.facingLeft;
    }

    private void ResetThrow()
    {
        throwDone = true;
    }
}


