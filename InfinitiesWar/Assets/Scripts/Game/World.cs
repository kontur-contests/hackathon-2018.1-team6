using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
    [SerializeField]
    AudioClip backgroundAudioClip;
    [SerializeField]
    AudioSource backgroudAudioSource;

    BackgroundSlider backgroundSlider;
    [SerializeField]
    public PlayerActions player;
    [SerializeField]
    public ControllerOfNumbers numbersController;
    [SerializeField]
    public ScoreBoardLoader scoreBoardLoader;
    public bool isRunning = true;
    public static World world;

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
    }
}
