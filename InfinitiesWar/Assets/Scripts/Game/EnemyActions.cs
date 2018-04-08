using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour {

    [SerializeField]
    TextMesh Enemy;

    [SerializeField]
    Transform leftBound;
    [SerializeField]
    Transform rightBound;

    [SerializeField]
    BackgroundSlider enemySpeed;

    public int CurrentNumber;

    // Use this for initialization
    private void Start()
    {
        var enemy = World.world.player;
        CurrentNumber = GetValideNumber(enemy.CurrentNumber);
    }

    // Update is called once per frame
    private void Update()
    {
        if (World.world.isRunning)
        {
            transform.position -= new Vector3(enemySpeed.speed, 0, 0) * Time.deltaTime;

            if (transform.position.x < leftBound.position.x)
                DestroyEnemy();

            Enemy.text = CurrentNumber.ToString();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        FindObjectOfType<ControllerOfNumbers>().Dequeue();
    }

    private int GetValideNumber(int curr)
    {
        var curQueue = World.world.numbersController.enemies;
        var copy = new Queue<EnemyActions>(curQueue);
        copy.ToArray();
        var CNums = new List<int>();
        bool[,] d = new bool[copy.Count, 10];
        for (var i = 0; i < copy.Count; ++i)
            for (var j = 0; j < 10; ++j)
                d[i, j] = false;
        foreach (var elem in ValideNumbers(curr))
        {
            d[0, elem] = true;
        }
        for (var i = 1; i < copy.Count; ++i)
        {
            for (var j = 1; j < 10; ++j)
                if (d[i - 1, j])
                    foreach (var elem in ValideNumbers(j))
                        d[i, elem] = true;
        }
        var answer = new List<int>();
        for (var i = 1; i < 10; ++i)
        {
            if (d[copy.Count - 1, i])
                answer.Add(i);
        }
        return answer[(int)Random.Range(0, answer.Count)];
    }

    private List<int> ValideNumbers(int curr)
    {
        var valideNumbers = new List<int>();
        for (int i = 1; i < 10; ++i)
        {
            if (isValid(i, curr))
                valideNumbers.Add(i);
        }
        return valideNumbers;
    }

    private bool isValid(int i, int curr)
    {
        return i + curr < 10 || curr - i > 0 || i * curr < 10 || (curr % i == 0 && curr / i > 0);
    }
}
