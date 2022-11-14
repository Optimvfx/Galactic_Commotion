using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public float _shieldCooldown;
    [HideInInspector] public bool _isShieldCooldown;

    public Image _shieldTimeCanvas;
    public GameObject _playerShield;

    void Start() 
    {
        _shieldTimeCanvas = GetComponent<Image>();
    }

    void Update() 
    {
        CheckShieldColldown();
    }

    public void ResetShieldTimer() 
    {
        _shieldTimeCanvas.fillAmount = 1;
    }

    void CheckShieldColldown()
    {
        if (_isShieldCooldown == true)
        {
            _shieldTimeCanvas.fillAmount -= 1 / _shieldCooldown * Time.deltaTime;

            if (_shieldTimeCanvas.fillAmount <= 0)
            {
                _shieldTimeCanvas.fillAmount = 1;
                _isShieldCooldown = false;
                _playerShield.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }
}
