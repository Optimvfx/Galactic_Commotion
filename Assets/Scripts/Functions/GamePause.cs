using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject _bossSummonPanel;

    public void BossContinueButtonDown() 
    {
        Destroy(_bossSummonPanel);
    }

    public void PauseButtonDown() 
    {
        Time.timeScale = 0;
    }

    public void ContinueButtonDown() 
    {
        Time.timeScale = 1;
    }
}
