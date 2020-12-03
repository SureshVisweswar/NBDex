using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button profileButton;
    [SerializeField] private Button NBDexButton;

    private void Awake() {
        Assert.IsNotNull(profileButton);
        Assert.IsNotNull(NBDexButton);
    }

    public void openProfileMenu() {
        Debug.Log("In Prof Func");
    }

    public void openNBDex() {
        Debug.Log("In NB Func");
    }
}
