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

            if (transform.position.x <= -8)
            {
                DestroyEnemy();
                World.world.Stop();
            }

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
        var CNums = new List<int>();
        for (int i = 1; i < 10; ++i)
        {
            if (isValid(i, curr))
                CNums.Add(i);
        }
        return CNums[(int)Random.Range(0, CNums.Count)];
    }

    private bool isValid(int i, int curr)
    {
        return i + curr < 10 || curr - i > 0 || i * curr < 10 || (curr % i == 0 && curr / i > 0);
    }
}
