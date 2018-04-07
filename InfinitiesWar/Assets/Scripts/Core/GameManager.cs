using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public string PlayerName { get; private set; }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }
}
