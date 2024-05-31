using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Professor : MonoBehaviour
{
    [SerializeField] ImportfromPort _signal;
    [SerializeField] Animator[] _animators;
    [SerializeField] Skill[] _skills;
    [SerializeField] float _skillChoiceTimer = 0.7f;
    [SerializeField] float _lengthOfRound = 60;
    [SerializeField] int _gameOverScene;
    [SerializeField] int _thisScene = 1;
    [SerializeField] Image _batteryImage;
    [SerializeField] Image[] _icons;

    float _batteryTimer = 1;
    float _choiceTimer = 0;
    [SerializeField] float _invPlayTime;
    [SerializeField] int _skillIndex = 0;
    bool _prevFrame = false;

    private void Start()
    {
        _invPlayTime = 1 / _lengthOfRound;
        foreach (Image image in _icons)
        {
            if(image.gameObject != _icons[0].gameObject) image.CrossFadeAlpha(0.3f, 0.05f, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        SkillCarousel();
        BatteryTimer();
        Haste();
    }

    void SkillCarousel()
    {
        if (_signal._input2)
        {
            _prevFrame = true;
            if ((_choiceTimer += Time.deltaTime) > _skillChoiceTimer)
            {
                _choiceTimer = 0;

                _icons[_skillIndex].CrossFadeAlpha(0.3f, 0.05f, true);
                if (++_skillIndex >= _skills.Length)
                {
                    _skillIndex = 0;
                }
                _icons[_skillIndex].CrossFadeAlpha(1, 0.05f, true);
            }
        }
        else if (_prevFrame)
        {
            _prevFrame = false;
            if (_skills[_skillIndex].Call(out string id)) foreach (Animator animator in _animators) animator.SetTrigger(id);
            _choiceTimer = 0;
        }

        
    }

    void BatteryTimer()
    {
        _batteryTimer -= Time.deltaTime * _invPlayTime;
        _batteryImage.fillAmount = _batteryTimer;
        if (_batteryTimer > _lengthOfRound)
        {
            if(CountRounds.GameOver(true) == 1) SceneManager.LoadScene(_gameOverScene);
            else SceneManager.LoadScene(_thisScene);
        }
    }

    void Haste()
    {
        Skill._coolDownMultiplier = _batteryTimer;
    }
}
