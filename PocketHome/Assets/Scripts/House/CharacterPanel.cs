using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField]
    GameObject characterPanel;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void onClickCharacterPanel()
    {
        if(characterPanel.activeSelf)
            characterPanel.SetActive(false);
        else
            characterPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
