using UnityEngine;

public class BossPatrol : MonoBehaviour 
{
	public float _bossSpeed;
	public float _bossHealth;

	public Transform[] moveSpots;
	private int _randomSpot;

	public float _laserDamage;
	public GameObject _laserHitParticle;

	public Animator _cameraShake;
	public AudioSource _explosion;
	public GameObject _goldCoin;

	public Player _player;

	void Start () 
	{
		_player = GetComponent<Player>();
		_randomSpot = Random.Range(0, moveSpots.Length);
	}

	void Update () 
	{
		BossMove();
	}

	void OnCollisionEnter2D(Collision2D collision) 
	{
		if (collision.gameObject.tag == "Laser")
		{
			Destroy(collision.gameObject);
            Instantiate(_laserHitParticle, transform.position, Quaternion.identity);
            _bossHealth = _bossHealth - _laserDamage;
		}
	}

	void BossMove()
	{
		transform.position = Vector3.MoveTowards(transform.position, moveSpots[_randomSpot].position, _bossSpeed * Time.deltaTime);
		if (Vector2.Distance(transform.position, moveSpots[_randomSpot].position) < 0.2)
		{
			_randomSpot = Random.Range(0, moveSpots.Length);
		}

		if (_bossHealth <= 0)
		{
			_explosion.Play();
			Destroy(gameObject);
            _cameraShake.SetTrigger("shake");
			Instantiate(_goldCoin, transform.position, Quaternion.identity);
		}
	}
}