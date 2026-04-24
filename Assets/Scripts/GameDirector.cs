using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDirector : MonoBehaviour {

    [SerializeField]
    GameObject player;
    GameObject Player;
    [SerializeField]
    TextMeshProUGUI timer;
    [SerializeField]
    TextMeshProUGUI Score;
    [SerializeField]
    GameObject respown;
    [SerializeField]
    WallScript wallScript;
    [SerializeField]
    TextMeshProUGUI pressZ;
    [SerializeField]
    TextMeshProUGUI pressR;
    [SerializeField]
    TextMeshProUGUI Title;
    [SerializeField]
    TextMeshProUGUI respownPointText;
    [SerializeField]
    GameObject respownPoint;
    [SerializeField]
    TextMeshProUGUI speedUp;
    [SerializeField]
    TextMeshProUGUI ScoreResult;
    [SerializeField]
    GameObject ranking, tweet;
    AudioSource crystal;
    AudioSource bomb;
    AudioSource warning;
    public static int score { get; private set; }
    float delta;
    float speedUpDelta;
    float second;
    bool playerSpowned;
    bool isStarted;
    int level;
    bool dead;

    // Use this for initialization
    void Start () {
        score = 0;
        dead = false;
        isStarted = false;
        timer.enabled = false;
        Score.enabled = false;
        pressZ.enabled = true;
        speedUp.enabled = false;
        respownPointText.enabled = true;
        respownPoint.SetActive(true);
        Title.enabled = true;
        pressR.enabled = false;
        ranking.SetActive(false);
        tweet.SetActive(false);
        ScoreResult.enabled = false;
        second = 60;
        playerSpowned = false;
        AudioSource[] sources = GetComponents<AudioSource>();
        crystal = sources[0];
        bomb = sources[1];
        warning = sources[2];
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead) {
            if (Input.GetKey(KeyCode.Z) && isStarted == false) {
                isStarted = true;
                timer.enabled = true;
                Score.enabled = true;
                pressZ.enabled = false;
                respownPointText.enabled = false;
                respownPoint.SetActive(false);
                Title.enabled = false;
            }
            if (isStarted) {
                delta += Time.deltaTime;
                speedUpDelta += Time.deltaTime;
                Timer();
                Score.text = ("Score:" + score.ToString("000"));
                ScoreResult.text = ("Score:" + score.ToString("000"));
                if (playerSpowned == false) PlayerSpown();
                playerSpowned = true;
            }
            if (speedUpDelta >= 3) {
                speedUp.enabled = false;
            }
        } else {
            Restart();
        }
    }

    void PlayerSpown() {
        Player = Instantiate(player) as GameObject;
        Player.transform.position = respown.transform.position;
    }

    void Timer() {
        second -= Time.deltaTime;;
        if(second > 0) {
            timer.text = (second.ToString("00"));
            if (delta >= 10) {
                delta = 0;
                wallScript.ChangeSpeed(0.02f);
                speedUp.enabled = true;
                warning.Play();
                speedUpDelta = 0;
            }
        } else {
            GameOver();
        }
    }

    public void TakeScore(int sc) {
        score += sc;
    }

    public void CrystalSound() {
        crystal.Play();
    }

    public void BombSound() {
        bomb.Play();
    }

    public void GameOver() {
        Destroy(Player);
        timer.enabled = false;
        Score.enabled = false;
        speedUp.enabled = false;
        pressR.enabled = true;
        ranking.SetActive(true);
        tweet.SetActive(true);
        ScoreResult.enabled = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        dead = true;
    }

    void Restart() {
        if (Input.GetKey(KeyCode.R)) {
            // 現在のScene名を取得する
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }
    }

    public void Ranking() {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
    }

    public void Tweet() {
        naichilab.UnityRoomTweet.Tweet("magmadash", score + "点分の宝石を手に入れた！", "マグマダッシュ", "unity1week");
    }
}
