using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class World : MonoBehaviour
{
    [SerializeField]
    AudioClip backgroundAudioClip;
    [SerializeField]
    AudioSource backgroudAudioSource;

    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text currentScoreText;

    BackgroundSlider backgroundSlider;
    [SerializeField]
    public PlayerActions player;
    [SerializeField]
    public ControllerOfNumbers numbersController;
    [SerializeField]
    public ScoreBoardLoader scoreBoardLoader;
    public bool isRunning = true;
    public static World world;

    public int Score { get; private set; }

    public void AddScore(int amount)
    {
        Score += amount;
        currentScoreText.text = Score.ToString();
    }

    private void Awake()
    {
        if (world == null)
            world = this;
    }

    private void OnDestroy()
    {
        world = null;
    }
    // Use this for initialization
    void Start()
    {
        backgroudAudioSource.clip = backgroundAudioClip;
        backgroudAudioSource.loop = true;
        backgroudAudioSource.Play();

        currentScoreText.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Stop()
    {
        EnemyActions enemy = numbersController.GetLast();
        if (enemy != null)
            enemy.DestroyEnemy();
        player.DestroyPlayer();
        isRunning = false;

        scoreBoardLoader.ShowBoard();
        scoreText.text = "Your score: " + Score.ToString();
    }
}
