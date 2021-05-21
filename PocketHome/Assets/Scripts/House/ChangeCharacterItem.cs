using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeCharacterItem : MonoBehaviour
{

    [SerializeField]
    GameObject[] theItem;
    [SerializeField]
    Sprite[] textureList;
    [SerializeField]
    int index;
    int lastIndex;
    Image[] imageComponent;
    // Start is called before the first frame update
    void Start()
    {
        imageComponent = new Image[theItem.Length];
        int i = 0;
        foreach (GameObject element in theItem)
        {
            imageComponent[i] = element.GetComponent<Image>();
            i++;
        }
        lastIndex = index;
        Debug.Log(imageComponent[0].ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClickChange()
    {
        if (index < textureList.Length - 1)
        {
            index++;
        }
        else
        {
            index = 0;
        }

        foreach (Image img in imageComponent)
        {
            img.sprite = textureList[index];
        }
    }
}
