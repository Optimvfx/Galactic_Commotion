using UnityEngine;
using UnityEngine.UI;

public class ChoosePlatform : MonoBehaviour
{
    public bool _pcDevise;
    public GameObject _mainCamera;

    public void PcButtonDown() 
    {
        _pcDevise = true;
        _mainCamera.layer = 9;
        Time.timeScale = 1;
    }

    public void PhoneButtonDown() 
    {
        _pcDevise = false;
        _mainCamera.layer = 1;
        Time.timeScale = 1;
    }
}
