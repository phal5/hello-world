using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackOut : MonoBehaviour
{
    [SerializeField] Image _blackOut;

    private void OnEnable()
    {
        _blackOut.CrossFadeAlpha(0, 0, true);
        _blackOut.CrossFadeAlpha(1, 1, true);
    }
}
