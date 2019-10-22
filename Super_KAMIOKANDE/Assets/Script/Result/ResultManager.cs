using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    
    [SerializeField] private GameObject scoreText;
    [SerializeField] private GameObject firstScoreText;
    [SerializeField] private GameObject secondScoreText;
    [SerializeField] private GameObject thirdScoreText;
    private int score;
    private static int[] RankingScore = {0,0,0};

    void Start()
    {
        Text score_Text = scoreText.GetComponent<Text>();
        Text firstScore_Text = firstScoreText.GetComponent<Text>();
        Text secondScore_Text = secondScoreText.GetComponent<Text>();
        Text thirdScore_Text = thirdScoreText.GetComponent<Text>();

        firstScore_Text.text = "1い:" + PlayerPrefs.GetInt("first", 0) + "m";
        secondScore_Text.text = "2い:" + PlayerPrefs.GetInt("second", 0) + "m";
        thirdScore_Text.text = "3い:" + PlayerPrefs.GetInt("third", 0) + "m";

        PlayerPrefs.SetInt("FirstScore", RankingScore[0]) ;

        score = (int)DistanceText.distance;
        
        score_Text.text = score.ToString() + "m";

        GetRanking();
        UpdateScore(score);
    }

    void UpdateScore(int newScore) {

        if (newScore >= PlayerPrefs.GetInt("first", 0)) {
            PlayerPrefs.SetInt("third", PlayerPrefs.GetInt("second", 0));
            PlayerPrefs.SetInt("second", PlayerPrefs.GetInt("first", 0));
            PlayerPrefs.SetInt("first", newScore);

        } else if (newScore >= PlayerPrefs.GetInt("second", 0)) {
            PlayerPrefs.SetInt("third", PlayerPrefs.GetInt("second", 0));
            PlayerPrefs.SetInt("second", newScore);

        } else if (newScore >= PlayerPrefs.GetInt("third", 0)) {
            PlayerPrefs.SetInt("third", newScore);

        }
        PlayerPrefs.Save();


    }

    public static void GetRanking() {

        RankingScore[0] = PlayerPrefs.GetInt("first");
        RankingScore[1] = PlayerPrefs.GetInt("second");
        RankingScore[2] = PlayerPrefs.GetInt("third");
    }

    public void ScoreReset() {

        PlayerPrefs.DeleteAll();
    }

}
