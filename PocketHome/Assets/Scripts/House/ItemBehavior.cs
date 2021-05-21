using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField]
    public int index;
    [SerializeField]
    public Sprite[] listofSprites;
    private SpriteRenderer spriteRenderer;
    private int lastIndex;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        lastIndex = index;
    }

    // Update is called once per frame
    void Update()
    {
        if(index!=lastIndex)
        {
            spriteRenderer.sprite = listofSprites[index];
            lastIndex = index;
        }
        
    }
}
