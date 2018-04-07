﻿using System.Collections;
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
        CurrentNumber = (int)Random.Range(1, 9);
    }

    // Update is called once per frame
    private void Update()
    {
        if (World.world.isRunning)
        {
            transform.position -= new Vector3(enemySpeed.speed, 0, 0) * Time.deltaTime;

            if (transform.position.x < leftBound.position.x)
            {
                Destroy(gameObject);
                FindObjectOfType<ControllerOfNumbers>().Dequeue();
            }
            Enemy.text = CurrentNumber.ToString();
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        FindObjectOfType<ControllerOfNumbers>().Dequeue();
    }
}
