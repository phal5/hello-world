using UnityEngine;

public class CountRounds : MonoBehaviour
{
    public static bool _1pWon;
    public static bool _2pWon;
    public static bool _switch = false;
    public static int _result;

    public static int GameOver(bool did1pWin)
    {
        _switch ^= true;
        if (did1pWin)
        {
            if (_1pWon) return (_result = 1);
            else
            {
                _1pWon = true;
                return 0;
            }
        }
        else
        {
            if (_2pWon) return (_result = 2);
            else
            {
                _2pWon = true;
                return 0;
            }
        }
    } 
}
