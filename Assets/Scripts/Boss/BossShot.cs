using UnityEngine;

public class BossShot : MonoBehaviour
{
    public AudioSource _laserShot;

    public GameObject _laser;
    
    public Transform _bossGunPoint;
    public Transform _bossGunPoint2;

    private float _timeShot;
    public float _delayBetweenShots;

    void Update() 
    {
        BossRechageCheck();
    }

    public void Shoot() 
    {
        Instantiate(_laser, _bossGunPoint.position, transform.rotation);
        Instantiate(_laser, _bossGunPoint2.position, transform.rotation);
        _timeShot = _delayBetweenShots;
    }

    void BossRechageCheck()
    {
        if (_timeShot <= 0)
        {
            _laserShot.Play();
            Shoot();
        }
        else
        {
            _timeShot -= Time.deltaTime;
        }
    }
}
