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

    // Update is called once per frame
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

        if (isValidOperation(result))
            player.CurrentNumber = result;
        else
        {
            Debug.Log("Operation is impossible");
            World.world.Stop();
        }
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
        Operate((a, b) => a / b);
    }

    private bool isValidOperation(int result)
    {
        return result > 0 && result < 10;
    }
}