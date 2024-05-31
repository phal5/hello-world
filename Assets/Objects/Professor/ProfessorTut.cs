using UnityEngine;
using UnityEngine.UI;

public class ProfessorTut : MonoBehaviour
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
    }

    void SkillCarousel()
    {
        if (_signal._input2 && _signal._input1)
        {
            if ((_choiceTimer += Time.deltaTime) > _skillChoiceTimer)
            {
                _choiceTimer = 0;

                _icons[_skillIndex].CrossFadeAlpha(0.3f, 0.05f, true);
                if (++_skillIndex >= _skills.Length)
                {
                    _skillIndex = 0;
                    _prevFrame = true;
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
}
