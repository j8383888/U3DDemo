using UnityEngine.UI;
using UnityEngine;

public class UI
{
    public Text scoreText;
    private int _score;

    public UI()
    {
        scoreText = GameObject.FindWithTag("Score").GetComponent<Text>();
    }

    public void addScore()
    {
        _score += 100;
        scoreText.text = "分数：" + _score.ToString();
    }
}
