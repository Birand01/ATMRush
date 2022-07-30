using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Text scoreText;
    public int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
        }
    }

    private void Update()
    {
        ScoreUpdate();
    }

    public void ScoreUpdate()
    {
        score = 0;
        int inventoryList = CollectList.Instance.inventory.Count;
        for (int i = 1; i < inventoryList; i++)
        {
            score += CollectList.Instance.inventory[i].GetComponent<Money>().value;
        }

        scoreText.text = score.ToString();
    }
}
