using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour {

    [SerializeField]
    TextMesh Enemy;

    public int CurrentNumber;

    // Use this for initialization
    void Start()
    {
        CurrentNumber = (int)Random.Range(1, 9);
    }

    // Update is called once per frame
    void Update()
    {
        Enemy.text = CurrentNumber.ToString();
    }
}
