using UnityEngine;

public class Player : MonoBehaviour
{
    public Joystick _moveJoystick;
    private Rigidbody2D _rigidbody;

    private Vector2 _moveInput;
    private Vector2 _moveVelocity;

    public float _playerSpeed;

    public Transform _fireParticlePoint;
    public GameObject _fireParticle;

    public GameObject _playerShield;

    public ChoosePlatform _platform;

    void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Time.timeScale = 0;
    }

    void Update() 
    {
        PlayerMove();
    }
    
    void PlayerMove()
    {
        if (_platform._pcDevise == true)
            _moveJoystick.gameObject.SetActive(false);

        if (_platform._pcDevise == true)
        {
            if (_moveInput.x != 0 || _moveInput.y != 0)
                Instantiate(_fireParticle, _fireParticlePoint.position, transform.rotation);

            _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        if (_platform._pcDevise == false)
        {
            if (_moveInput.x != 0 || _moveInput.y != 0)
                Instantiate(_fireParticle, _fireParticlePoint.position, transform.rotation);

            _moveInput = new Vector2(_moveJoystick.Horizontal, _moveJoystick.Vertical);
        }

        _moveVelocity = _moveInput.normalized * _playerSpeed;

        if (_playerShield.activeInHierarchy == true)
            _playerSpeed = 3;
        else
            _playerSpeed = 5.5f;
    }

    void FixedUpdate() 
    {
        _rigidbody.MovePosition(_rigidbody.position + _moveVelocity * Time.fixedDeltaTime);
    }
}
