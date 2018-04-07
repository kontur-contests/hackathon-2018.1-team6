using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour {

    [SerializeField]
    InputField playerNameInput;

    public void StartGame()
    {
        var manager = FindObjectOfType<GameManager>();

        var playerName = playerNameInput.text;
        manager.SetPlayerName(playerName);

        SceneManager.LoadScene("Game");
    }

}
