using UnityEngine;

public class ShieldAction : MonoBehaviour
{
    public GameObject _player;
    public GameObject _meteorBrakeParticle;
    public Animator _cameraShake;

    void Update() 
    {
        SheldAttaching();
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            _cameraShake.SetTrigger("shake");
            Instantiate(_meteorBrakeParticle, collision.transform.position, Quaternion.identity);
        }
    }

    void SheldAttaching()
    {
        transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y, -10);
    }
}
