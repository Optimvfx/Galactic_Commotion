using UnityEngine;
using UnityEngine.UI;

public class MeteorEnemy : MonoBehaviour
{
    public int _meteorHealth;
    public float _meteorSpeed;

    public Animator _cameraShake;
    public Player _player;

    public GameObject _laserHitParticle;
    public int _laserDamage;

    public GameObject _silverCoin;

    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    void Update()
    {
        MeteorDie();
        ChasePlayer();
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Laser")
        {
            Destroy(collision.gameObject);
            Instantiate(_laserHitParticle, transform.position, Quaternion.identity);
            _meteorHealth = _meteorHealth - _laserDamage;
        }
    }

    void MeteorDie()
    {
        if (_meteorHealth <= 0)
        {
            Destroy(gameObject);
            _cameraShake.SetTrigger("shake");
            Instantiate(_silverCoin, transform.position, Quaternion.identity);
        }
    }

    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, _player.transform.position, _meteorSpeed * Time.deltaTime);
    }
}
