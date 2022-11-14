using UnityEngine;

public class SkinChoose : MonoBehaviour
{
    public Sprite[] _skins;

    public GameObject _player;

    void Update()
    {
        SetSkin();
    }

    void SetSkin()
    {
        _player.GetComponent<SpriteRenderer>().sprite = _skins[PlayerPrefs.GetInt("skinNumber")];
    }
}
