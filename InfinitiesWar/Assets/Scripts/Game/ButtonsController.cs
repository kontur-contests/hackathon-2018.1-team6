using UnityEngine;
using System.Collections;
using System;

public class ButtonsController : MonoBehaviour
{

    [SerializeField]
    PlayerActions player;

    [SerializeField]
    EnemyActions enemy;
    // Use this for initialization
    void Start()
    {

    }

    void Update()
    {
        
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

        if (!isValidOperation(result))
            World.world.Stop();
    }

    public void Add()
    {
        Operate((a, b) => a + b);
    }

    public void Subtract()
    {
        Operate((a, b) => a - b);
    }

    public void Multiply()
    {
        Operate((a, b) => a * b);
    }

    public void Divide()
    {
        var playerNumber = player.CurrentNumber;
        var enemy = World.world.numbersController.GetLast();

        if (enemy == null)
            return;

        var enemyNumber = enemy.CurrentNumber;

        player.CurrentNumber = (int) (playerNumber / enemyNumber);

        if (playerNumber % enemyNumber != 0)
            World.world.Stop();
    }

    private bool isValidOperation(int result)
    {
        return result > 0 && result < 10;
    }
}