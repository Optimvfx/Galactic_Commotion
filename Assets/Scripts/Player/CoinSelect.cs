using UnityEngine;
using UnityEngine.UI;

public class CoinSelect : MonoBehaviour
{
	public AudioSource _pickUpCoin;
    public Text _coinQualityCanvas;
	public int _coinQuality;

	public Text _balanceQualityCanvas;

	void Start () 
	{
		UploadSave();
	}

	void OnTriggerEnter2D (Collider2D other) 
	{
		if(other.tag == "SilverCoin")
		{
			Destroy(other.gameObject);
			_coinQuality = _coinQuality + 1;
			_pickUpCoin.Play();
			PlayerPrefs.SetInt("Coins", _coinQuality);
			_coinQualityCanvas.text = ": " + _coinQuality.ToString();

			_balanceQualityCanvas.text = ": " + _coinQuality.ToString() + "$";
		}

        if(other.tag == "GoldCoin") 
		{
			Destroy(other.gameObject);
			_coinQuality = _coinQuality + 50;
			_pickUpCoin.Play();
			_coinQualityCanvas.text = ": " + _coinQuality.ToString();

			_balanceQualityCanvas.text = ": " + _coinQuality.ToString() + "$";
		}
	}

	void UploadSave()
	{
		if (PlayerPrefs.HasKey("Coins"))
		{
			_coinQuality = PlayerPrefs.GetInt("Coins");
			
			_coinQualityCanvas.text = ": " + _coinQuality.ToString();
			_balanceQualityCanvas.text = ": " + _coinQuality.ToString() + "$";
		}
	}
}
