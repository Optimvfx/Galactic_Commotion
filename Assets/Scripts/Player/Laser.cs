using UnityEngine;

public class Laser : MonoBehaviour
{
    public float _laserSpeed;
    public float _laserLifeTime;
    public float _laserDistance;

    void Start() 
    {
        Invoke("DestroyLaser", _laserLifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _laserSpeed * Time.deltaTime);
    }

    public void DestroyLaser()
    {
        Destroy(gameObject);
    }
}
