using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthSistem : MonoBehaviour
{
    public GameObject _gameOverPanel;
    public Text _hpValueCanvas;

    private Rigidbody2D _rigidbody;
    private Player _player;
    
    public float _laserDamage;
    public float _meteorDamage;
    public GameObject _enemyHitParticle;
    
    public float _healthKitRecovery;
    public float _playerHealth;

    public GameObject _playerShield;
    public Shield _shieldTimer;

    public GameObject _bossSummonPanel;
    public bool _bossSummonFirstTime = false;
    public bool _bossSummonSecondTime = false;
    public bool _bossSummonThirdTime = false;

    private void Start() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();

        _hpValueCanvas.text = "HP: " + _playerHealth.ToString();
    }

    void Update() 
    {
        PlayerDie();
        BossSummon();
    }

    void PlayerDie()
    {
        if (_playerHealth <= 0)
        {
            _gameOverPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Instantiate(_enemyHitParticle, transform.position, Quaternion.identity);
            _playerHealth = _playerHealth - _meteorDamage;
            _hpValueCanvas.text = "HP: " + _playerHealth.ToString();
        }

        if (collision.gameObject.tag == "Laser")
        {
            Instantiate(_enemyHitParticle, transform.position, Quaternion.identity);
            _playerHealth = _playerHealth - _laserDamage;
            _hpValueCanvas.text = "HP: " + _playerHealth.ToString();
        }

        if (collision.gameObject.tag == "Boss")
        {
            _playerHealth = 0;
            _gameOverPanel.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "HealthKit")
        {
            Destroy(other.gameObject);
            _playerHealth = _playerHealth + _healthKitRecovery;
            _hpValueCanvas.text = "HP: " + _playerHealth.ToString();
        }

        if (other.tag == "Shield")
        {
            _playerShield.SetActive(true);
            _shieldTimer._isShieldCooldown = true;
            _shieldTimer.gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }

    void BossSummon()
	{
		if (_playerHealth >= 30 && _bossSummonFirstTime == false)
		{
            _bossSummonFirstTime = true;
			_bossSummonPanel.SetActive(true);
		}

        if (_playerHealth >= 60 && _bossSummonSecondTime == false)
		{
            _bossSummonSecondTime = true;
			_bossSummonPanel.SetActive(true);
		}

        if (_playerHealth >= 100 && _bossSummonThirdTime == false)
		{
            _bossSummonThirdTime = true;
			_bossSummonPanel.SetActive(true);
		}
	}
}
