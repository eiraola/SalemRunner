using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MovementStats {
    [SerializeField] private float _jumpHeigth;
    [SerializeField] private float _timeToJumpApex;
    [SerializeField] private float _maxFallVelocity ;
    [SerializeField] private float _fallGravitymultiplier;
    [SerializeField] private float _jumpReleasedSpeedLose;
    [SerializeField] private float _maxAppexPoint;
    [SerializeField] private float _maxAppexSpeed;
    [SerializeField] private float _jumpInputBuffer;
    [HideInInspector] public bool isJumpButtonPressed = false;
    [HideInInspector] public float lastTimeJumpPressed = 0.0f;
    public GroundCollision groundCollision;
    private float _gravityForce;
    private float _jumpForce;
    public float JumpHeigth { get => _jumpHeigth; }
    public float TimeToJumpApex { get => _timeToJumpApex;}
    public float MaxFallVelocity { get => _maxFallVelocity;}
    public float FallGravitymultiplier { get => _fallGravitymultiplier;}
    public float JumpReleasedSpeedLose { get => _jumpReleasedSpeedLose;}
    public float MaxAppexPoint { get => _maxAppexPoint;}
    public float MaxAppexSpeed { get => _maxAppexSpeed;}
    public float JumpInputBuffer { get => _jumpInputBuffer;}
    public float GravityForce { get => _gravityForce;}
    public float JumpForce { get => _jumpForce;}

    public void Initialize(GroundCollision newGroundCollision) {
        _gravityForce = -(2 * _jumpHeigth) / Mathf.Pow(_timeToJumpApex, 2);
        _jumpForce = Mathf.Abs(GravityForce) * _timeToJumpApex;
        groundCollision = newGroundCollision;
    }

    public float DistanceToGround()
    {
        return groundCollision.DistanceToGround();
    }
}
public class JumpHandler : MonoBehaviour
{
    [SerializeField] private MovementStats _jumpStats = new MovementStats();
    [SerializeField] private LayerMask _layersToIgnore = new LayerMask();
    [SerializeField] private UnityEvent<bool> _onGrounded = new UnityEvent<bool>();
    [SerializeField] private JumpBaseSO _mainJumpMode;
    [SerializeField] private SoundSignalSO _soundSignalSO;
    bool _isInAir = true;
    private JumpBaseSO _currentJumpMode;
    private Vector3 _targetSpeed = Vector3.zero;
    private Vector3 _currentSpeed = Vector3.zero;
    private GroundCollision _groundCollision;

    private void Start()
    {
        _groundCollision = new GroundCollision(GetComponent<BoxCollider2D>(), _layersToIgnore);
        _jumpStats.Initialize(_groundCollision);
        InitializeJumpMode(_mainJumpMode);
    }

    private void Update()
    {
        Move();
        CheckJump();
        transform.position += _currentSpeed;
       
    }
    private void Move()
    {
        _targetSpeed.y = CalculateVerticalVelocity();
        _currentSpeed = _targetSpeed * Time.deltaTime;
        ConstraintFallSpeed();
    }

    private float CalculateVerticalVelocity()
    {
        return _currentJumpMode.CalculateVerticalVelocity(_targetSpeed.y);
    }

    private void ConstraintFallSpeed()
    {
        if (_currentSpeed.y >= 0.0f)
        {
            if (!_isInAir)
            {
                _onGrounded?.Invoke(false);
                _isInAir = true;
            }
           
            return;
        }
        float collisionSpeed = _groundCollision.DistanceToGround();
        if (-collisionSpeed > _currentSpeed.y) {
            _currentSpeed.y = -collisionSpeed; 
        }
        if (collisionSpeed < 0.001f) {
            if (_isInAir)
            {
                PlaySound(EClip.Land);
                _onGrounded?.Invoke(true);
                _isInAir = false;
            }
            _currentSpeed.y = 0.0f;
        }
    }
    public void CheckJump() {
        _targetSpeed.y = _currentJumpMode.CheckJump(_targetSpeed.y);
    }
    public void JumpAction() {
        _targetSpeed.y = _currentJumpMode.JumpAction(_targetSpeed.y);
    }

    public void OnJumpReleased()
    {
        _targetSpeed.y = _currentJumpMode.OnJumpReleased(_targetSpeed.y);
    }

    private void InitializeJumpMode(JumpBaseSO newJump)
    {
        if (_currentJumpMode)
        {
            _currentJumpMode.Deactivate();
        }

        _currentJumpMode = newJump;
        _currentJumpMode.Init(PlaySound, _jumpStats);
    }

    private void PlaySound(EClip clip) 
    {
        _soundSignalSO.PlayClipSound(clip);
    }

}
