using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ButtonsController : MonoBehaviour
{

    [SerializeField]
    PlayerActions player;

    [SerializeField]
    EnemyActions enemy;
    [SerializeField]
    private int score;
    [SerializeField]
    private Text scoreText;
    // Use this for initialization
    void Start()
    {
        scoreText.text = "";
    }

    void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyUp(KeyCode.KeypadPlus))
            Add();

        if (Input.GetKeyUp(KeyCode.KeypadMinus))
            Subtract();

        if (Input.GetKeyUp(KeyCode.KeypadMultiply))
            Multiply();

        if (Input.GetKeyUp(KeyCode.KeypadDivide))
            Divide();
    }

    public void Operate(Func<int, int, int> operate)
    {
        var playerNumber = player.CurrentNumber;
        var enemy = World.world.numbersController.GetLast();

        if (enemy == null)
            return;

        var enemyNumber = enemy.CurrentNumber;
        var result = operate(playerNumber, enemyNumber);

        player.CurrentNumber = result;
        score++;
        World.world.numbersController.GetLast().DestroyEnemy();

        if (!isValidOperation(result))
        {
            World.world.Stop();
            score--;
            scoreText.text = "Your score: " + score.ToString();
        }
    }

    public void Add()
    {
        if (World.world.isRunning)
            Operate((a, b) => a + b);
    }

    public void Subtract()
    {
        if (World.world.isRunning)
            Operate((a, b) => a - b);
    }

    public void Multiply()
    {
        if (World.world.isRunning)
            Operate((a, b) => a * b);
    }

    public void Divide()
    {
        if (!World.world.isRunning)
            return;

        var playerNumber = player.CurrentNumber;
        var enemy = World.world.numbersController.GetLast();

        if (enemy == null)
            return;

        var enemyNumber = enemy.CurrentNumber;

        player.CurrentNumber = (int) (playerNumber / enemyNumber);
        score++;
        World.world.numbersController.GetLast().DestroyEnemy();

        if (playerNumber % enemyNumber != 0)
        {
            World.world.Stop();
            score--;
            scoreText.text = "Your score: " + score.ToString();
        }
    }

    private bool isValidOperation(int result)
    {
        return result > 0 && result < 10;
    }
}