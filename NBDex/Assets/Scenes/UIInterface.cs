using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIInterface : MonoBehaviour
{
    [SerializeField] private Button Info;
    
    [SerializeField] private GameObject InfoMenu;
    [SerializeField] private GameObject InfoBackground;

    private void Awake()
    {
        Assert.IsNotNull(Info);
        
    }

    public void openInfoMenu()
    {
        Info.gameObject.SetActive(false);
        
        InfoMenu.gameObject.SetActive(true);
    }

    public void closeInfoMenu()
    {
        Info.gameObject.SetActive(true);        
        InfoMenu.gameObject.SetActive(false);
    }
}
