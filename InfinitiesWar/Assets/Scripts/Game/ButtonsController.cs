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

    public void Operate(int result)
    {
        if (isValidOperation(result))
        {
            player.CurrentNumber = (int) result;
        }
        else
        {
            Debug.Log("Operation is impossible");
        }
    }

    public void Add()
    {
        Operate(player.CurrentNumber + enemy.CurrentNumber);
    }

    public void Subtract()
    {
        Operate(player.CurrentNumber - enemy.CurrentNumber);
    }

    public void Multiply()
    {
        Operate(player.CurrentNumber * enemy.CurrentNumber);
    }

    public void Divide()
    {
        if (player.CurrentNumber % enemy.CurrentNumber == 0)
            Operate(player.CurrentNumber / enemy.CurrentNumber);
        Debug.Log("Divide is impossible");
    }

    private bool isValidOperation(int result)
    {
        return result > 0 && result < 10;
    }
}