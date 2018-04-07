using UnityEngine;
using System.Collections;

public class BackgroundSlider : MonoBehaviour {

    [SerializeField]
    Transform leftBound;
    [SerializeField]
    Transform rightBound;

    [SerializeField]
    public float speed = 1;
    [SerializeField]
    float boost = 0.00003f;
    [SerializeField]
    float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

        if(transform.position.x < leftBound.position.x)
        {
            transform.position = new Vector3(rightBound.position.x - leftBound.transform.position.x + transform.position.x, transform.position.y, transform.position.z);
        }

        //Max speed = 5
        if (speed < maxSpeed)
        {
            speed += boost * Time.deltaTime;
        }
        else
        {
            speed = maxSpeed;
        }
	}
}
