using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Potato : MonoBehaviour
{
    [SerializeField] int _gameOverScene;
    [SerializeField] int _thisScene = 1;
    [SerializeField] int _hp = 5;
    [SerializeField] int _invincibility = 1;
    [SerializeField] GameObject _blackOutObject;
    [SerializeField] TextMeshProUGUI _hpView;
    [SerializeField] Image _hpViewImage;
    [SerializeField] Image _blackOut;
    
    float _invincibilityTimer = 0;
    float _timer = 1;
    bool _gameOver = false;

    private void Update()
    {
        if(_gameOver)
        {
            GameOver();
        }
        InvincibilityTimer();
        
    }

    public void Damage(int amount)
    {
        if(_invincibilityTimer == 0)
        {
            _hp -= amount;
            _hpView.text = ((5 - _hp) * 20).ToString() + "%";
            _hpViewImage.fillAmount = (5 - _hp) * 0.2f;

            if (_hp < 1)
            {
                _gameOver = true;
                _blackOutObject.SetActive(true);
            }
            _invincibilityTimer = _invincibility;
        }
    }

    void InvincibilityTimer()
    {
        if(_invincibilityTimer > 0 && (_invincibilityTimer -= Time.deltaTime) < 0)
        {
            _invincibilityTimer = 0;
        }
    }

    void GameOver()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            if(CountRounds.GameOver(false) == 2) SceneManager.LoadScene(_gameOverScene);
            else SceneManager.LoadScene(_thisScene);
        }
    }
}
