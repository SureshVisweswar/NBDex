using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button profileButton;
    [SerializeField] private Button NBDexButton;
    [SerializeField] private GameObject ProfileMenu;
    [SerializeField] private GameObject NBDexMenu;
    [SerializeField] private GameObject ProfileBackground;
    [SerializeField] private GameObject CollectionBackground;

    private void Awake() {
        Assert.IsNotNull(profileButton);
        Assert.IsNotNull(NBDexButton);
    }

    public void openProfileMenu() {
        profileButton.gameObject.SetActive(false);
        NBDexButton.gameObject.SetActive(false);
        ProfileMenu.gameObject.SetActive(true);
    }

    public void openNBDex() {
        profileButton.gameObject.SetActive(false);
        NBDexButton.gameObject.SetActive(false);
        NBDexMenu.gameObject.SetActive(true);
    }

    public void closeProfileMenu() {
        profileButton.gameObject.SetActive(true);
        NBDexButton.gameObject.SetActive(true);
        ProfileMenu.gameObject.SetActive(false);
    }

    public void closeNBDex()
    {
        profileButton.gameObject.SetActive(true);
        NBDexButton.gameObject.SetActive(true);
        NBDexMenu.gameObject.SetActive(false);
    }

    public void openCollectionMenu()
    {
        ProfileBackground.gameObject.SetActive(false);
        CollectionBackground.gameObject.SetActive(true);
    }

    public void closeCollectionMenu()
    {
        ProfileBackground.gameObject.SetActive(true);
        CollectionBackground.gameObject.SetActive(false);
    }
}
