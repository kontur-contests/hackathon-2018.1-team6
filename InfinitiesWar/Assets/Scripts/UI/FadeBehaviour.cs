using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBehaviour : MonoBehaviour{

    [SerializeField]
    Image blackImage;
    [SerializeField]
    float speed;
    float state;

    protected void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FadeOut();
        if (Input.GetMouseButtonDown(1))
            FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        StartCoroutine(FadeOutCoroutine());
    }

        IEnumerator FadeOutCoroutine()
    {
        while (state < 1)
        {
            state += speed * Time.deltaTime;
            var color = blackImage.color;
            color.a = state;
            blackImage.color = color;

            yield return null;
        }
        {
            state = 1;
            var color = blackImage.color;
            color.a = state;
            blackImage.color = color;
        }
    }

    IEnumerator FadeInCoroutine()
    {
        while (state > 0)
        {
            state -= speed * Time.deltaTime;
            var color = blackImage.color;
            color.a = state;
            blackImage.color = color;

            yield return null;
        }
        {
            state = 0;
            var color = blackImage.color;
            color.a = state;
            blackImage.color = color;
        }
    }

}
