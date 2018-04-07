using UnityEngine;
using System.Collections;

public class ButtonsController : MonoBehaviour
{

    [SerializeField]
    PlayerActions player;

    [SerializeField]
    EnemyActions enemy;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Add()
    {
        Debug.Log("Add called");
    }

    public void Subtract()
    {
        Debug.Log("Subtract called");
    }

    public void Multiply()
    {
        Debug.Log("Multiply called");
    }

    public void Divide()
    {
        Debug.Log("Divide called");
    }
}