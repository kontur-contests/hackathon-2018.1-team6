using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerOfNumbers : MonoBehaviour {

    [SerializeField]
    EnemyActions enemyPrefab;

    [SerializeField]
    public int current;

    public int reloud;
    public Queue<EnemyActions> enemies = new Queue<EnemyActions>() ;
    int previos;
    PlayerActions playerNumber;

	// Use this for initialization
	void Start () {
        reloud = 1;
        StartCoroutine(Generate());
    }
	
	// Update is called once per frame
	void Update () {
		if (reloud % 30 == 0)
        {
            current = Random.Range(1, 9);
            previos = current;
        }
        ++reloud;
	}

    IEnumerator Generate()
    {
        yield return new WaitForSeconds(2);

        var enemy = Instantiate(enemyPrefab);
        enemy.gameObject.SetActive(true);

        enemies.Enqueue(enemy);

        StartCoroutine(Generate());
    }

    public void Dequeue()
    {
        enemies.Dequeue();
    }

    public EnemyActions GetLast()
    {
        if (enemies.Count > 0)
            return enemies.Peek();
        else
            return null;
    }
}
