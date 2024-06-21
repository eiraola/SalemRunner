using UnityEngine;
using UnityEngine.Events;

public class JumpHandler : MonoBehaviour
{
    [SerializeField] private float _jumpHeigth = 1f;
    [SerializeField] private float _timeToJumpApex = 1f;
    [SerializeField] private float _maxFallVelocity = 10f;
    [SerializeField] private float _fallGravitymultiplier = 10f;
    [SerializeField] private float _jumpReleasedSpeedLose = 2f;
    [SerializeField] private float _maxAppexPoint = 0.2f;
    [SerializeField] private float _maxAppexSpeed = 0.5f;
    [SerializeField] private float _jumpInputBuffer = 0.1f;
    [SerializeField] private LayerMask _layersToIgnore = new LayerMask();
    [SerializeField] private UnityEvent<bool> _onGrounded = new UnityEvent<bool>();
    private Vector3 _targetSpeed = Vector3.zero;
    private Vector3 _currentSpeed = Vector3.zero;
    private GroundCollision _groundCollision;
    private float _gravityForce = 0;
    private float _jumpForce = 0;
    private bool _isJumpButtonPressed = false;
    private float _lastTimeJumpPressed = 0.0f;

    private void Start()
    {
        _gravityForce = -(2 * _jumpHeigth) / Mathf.Pow(_timeToJumpApex, 2);
        _jumpForce = Mathf.Abs(_gravityForce) * _timeToJumpApex;
        _groundCollision = new GroundCollision(GetComponent<BoxCollider2D>(), _layersToIgnore);
    }

    private void Update()
    {
        Move();
        CheckJump();
        transform.position += _currentSpeed;
        _onGrounded?.Invoke(_currentSpeed.y == 0.0f);
    }
    private void Move()
    {
        _targetSpeed.y = CalculateVerticalVelocity();
        _currentSpeed = _targetSpeed * Time.deltaTime;
        ConstraintFallSpeed();
    }

    private float CalculateVerticalVelocity()
    {
        float finalGravityForce = _gravityForce;
        if (_targetSpeed.y < 0.0f)
        {
            finalGravityForce = _gravityForce * _fallGravitymultiplier;
        }
        if (_isJumpButtonPressed && Mathf.Abs(_targetSpeed.y) < _maxAppexPoint)
        {
            finalGravityForce = _gravityForce * _maxAppexSpeed;
        }
        if (_targetSpeed.y  < -_maxFallVelocity)
        {
            return -_maxFallVelocity;
        }

        return _targetSpeed.y + finalGravityForce * Time.deltaTime;
    }

    private void ConstraintFallSpeed()
    {
        if (_currentSpeed.y >= 0.0f)
        {
            return;
        }
        float collisionSpeed = _groundCollision.DistanceToGround();
        if (-collisionSpeed > _currentSpeed.y) {
            _currentSpeed.y = -collisionSpeed; 
        }
        if (collisionSpeed < 0.001f) {
            _currentSpeed.y = 0.0f;
        }
    }
    public void CheckJump() {
        if (_groundCollision.DistanceToGround() < 0.001f && _isJumpButtonPressed && (_lastTimeJumpPressed + _jumpInputBuffer) > Time.time )
        {
            _targetSpeed.y = _jumpForce;
        }
    }
    public void JumpAction() {
        _isJumpButtonPressed = true;
        _lastTimeJumpPressed = Time.time;
    }

    public void OnJumpReleased()
    {
        _isJumpButtonPressed = false;
        if (_targetSpeed.y > 0.0f)
        {
            _targetSpeed.y = _targetSpeed.y / _jumpReleasedSpeedLose;
        }
    }

}
