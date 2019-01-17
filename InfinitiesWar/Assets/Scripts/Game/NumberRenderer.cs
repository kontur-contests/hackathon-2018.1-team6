using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRenderer : MonoBehaviour {

    [SerializeField]
    Sprite number1;
    [SerializeField]
    Sprite number2;
    [SerializeField]
    Sprite number3;
    [SerializeField]
    Sprite number4;
    [SerializeField]
    Sprite number5;
    [SerializeField]
    Sprite number6;
    [SerializeField]
    Sprite number7;
    [SerializeField]
    Sprite number8;
    [SerializeField]
    Sprite number9;

    public int Number { get { return number; } set { if (number == value) return; number = value; dirty = true; } }
    private int number;
    private bool dirty;

    // Use this for initialization
    void Start () {
        Render();
	}
	
	// Update is called once per frame
	void Update () {
		if(dirty)
        {
            Render();
            dirty = false;
        }
	}

    private void Render()
    {
        for(var i = 0; i < transform.childCount; ++i)
        {
            var child = transform.GetChild(i);
            Destroy(child.gameObject);
        }
        var number = Number.ToString();
        Vector3 position = Vector3.zero;
        foreach(var digit in number)
        {
            switch (new string(new[] { digit }))
            {
                case "1":
                    RenderDigit(number1, ref position);
                    break;
                case "2":
                    RenderDigit(number2, ref position);
                    break;
                case "3":
                    RenderDigit(number3, ref position);
                    break;
                case "4":
                    RenderDigit(number4, ref position);
                    break;
                case "5":
                    RenderDigit(number5, ref position);
                    break;
                case "6":
                    RenderDigit(number6, ref position);
                    break;
                case "7":
                    RenderDigit(number7, ref position);
                    break;
                case "8":
                    RenderDigit(number8, ref position);
                    break;
                case "9":
                    RenderDigit(number9, ref position);
                    break;
                default:
                    continue;
            }
        }
    }

    void RenderDigit(Sprite number, ref Vector3 position)
    {
        var g = new GameObject();
        var sprite = g.AddComponent<SpriteRenderer>().sprite = number;
        g.transform.parent = transform;
        g.transform.localPosition = position;
        position += new Vector3(sprite.rect.width, 0, 0);
    }
}
