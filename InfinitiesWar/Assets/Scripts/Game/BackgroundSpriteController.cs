using System;
using UnityEngine;

public class BackgroundSpriteController : MonoBehaviour {

    [SerializeField]
    SpriteSet[] Sets;
    [SerializeField]
    SpriteRenderer background1;
    [SerializeField]
    SpriteRenderer background2;
    [SerializeField]
    SpriteRenderer ground1;
    [SerializeField]
    SpriteRenderer ground2;

    int index = 0;

    protected void Start()
    {
        SetSprite();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ChangeSprite();
    }

    public void ChangeSprite()
    {
        ++index;
        if (index == Sets.Length)
            index = 0;
        SetSprite();
    }

    void SetSprite()
    {
        var set = Sets[index];

        background1.sprite = set.BackgroudSrite;
        background2.sprite = set.BackgroudSrite;

        ground1.sprite = set.GroudSprite;
        ground2.sprite = set.GroudSprite;
    }

    [Serializable]
    public class SpriteSet
    {
        public Sprite BackgroudSrite;
        public Sprite GroudSprite;
    }
}
