using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreBoardLoader : MonoBehaviour {

    [SerializeField]
    GameObject restartButton;

    void Awake()
    {
        restartButton.SetActive(false);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowBoard()
    {
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
