using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static GameManager gameManager;

    public string PlayerName { get; private set; }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    private void Awake()
    {
        if (gameManager != null)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        gameManager = this;
    }
}
