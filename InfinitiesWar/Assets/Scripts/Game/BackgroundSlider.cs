using UnityEngine;
using System.Collections;

public class BackgroundSlider : MonoBehaviour {

    [SerializeField]
    Transform leftBound;
    [SerializeField]
    Transform rightBound;

    [SerializeField]
    float speed;
    [SerializeField]
    float boost;

	// Use this for initialization
	void Start () {
        boost = (float)0.00003;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position -= new Vector3(speed, 0, 0);

        if(transform.position.x < leftBound.position.x)
        {
            transform.position = new Vector3(rightBound.position.x - leftBound.transform.position.x + transform.position.x, transform.position.y, transform.position.z);
        }

        speed += boost;
	}
}
