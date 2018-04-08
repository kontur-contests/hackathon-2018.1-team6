using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour {

    [SerializeField]
    TextMesh Player;

    NumberRenderer numberRenderer;

    public int CurrentNumber;

    protected void Awake()
    {
        numberRenderer = GetComponent<NumberRenderer>();
    }

    // Use this for initialization
    void Start () {
		CurrentNumber = (int)Random.Range(1, 9);
	}
	
	// Update is called once per frame
	void Update () {
		//Player.text = CurrentNumber.ToString();
        numberRenderer.Number = CurrentNumber;
	}
}
