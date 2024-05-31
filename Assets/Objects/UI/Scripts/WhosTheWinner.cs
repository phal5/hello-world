using TMPro;
using UnityEngine;

public class WhosTheWinner : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _potatoLoses;
    [SerializeField] GameObject _professorLoses;

    // Start is called before the first frame update
    void Start()
    {
        _text.text = "Player" + CountRounds._result.ToString() + " Wins!";
        switch(CountRounds._result)
        {
            case 0:
                {
                    Debug.LogError("Fatal Error");
                    break;
                }
            case 1:
                {
                    if (CountRounds._switch)
                    {
                        //Player1 won while switching to professor
                        _professorLoses.SetActive(false);
                    }
                    else
                    {
                        _potatoLoses.SetActive(false);
                    }
                    break;
                }
            case 2:
                {
                    if (!CountRounds._switch)
                    {
                        //Player1 won while switching to professor
                        _professorLoses.SetActive(false);
                    }
                    else
                    {
                        _potatoLoses.SetActive(false);
                    }
                    break;
                }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
