using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private static int _score;

    private static ScoreKeeper _instance;

    public static ScoreKeeper GetInstance()
    {
        if (_instance == null)
        {
            _instance = FindObjectOfType<ScoreKeeper>();
        }
        return _instance;
    }

    public int GetScore()
    {
        return _score;
    }


    public void ModifyScore(int value)
    {
        _score += value;

        Mathf.Clamp(_score, 0, int.MaxValue);

        Debug.Log(_score);
    }

    public void ResetScore()
    {
        _score = 0;
    }
}
