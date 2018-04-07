using UnityEngine;
using System.Collections;

public class World : MonoBehaviour
{
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
        isRunning = false;
        scoreBoardLoader.ShowBoard();
    }
}
