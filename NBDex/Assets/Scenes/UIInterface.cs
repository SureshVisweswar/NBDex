using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInterface : MonoBehaviour
{
    [SerializeField] private Button Info;
    [SerializeField] private Button Building;
    [SerializeField] private Button EndEncounter;
    [SerializeField] private GameObject InfoMenu;
    [SerializeField] private GameObject BuildingMenu;
    [SerializeField] private GameObject animal;
    [SerializeField] private GameObject conMenu;
    [SerializeField] private GameObject failmenu;
    public string value = "nothing";
    

    private void Awake()
    {
        Assert.IsNotNull(Info);
        Assert.IsNotNull(Building);
        Assert.IsNotNull(EndEncounter);
    }

    public void openInfoMenu()
    {
        Info.gameObject.SetActive(false);
        EndEncounter.gameObject.SetActive(false);
        Building.gameObject.SetActive(false);
        InfoMenu.gameObject.SetActive(true);
    }

    public void closeInfoMenu()
    {
        Info.gameObject.SetActive(true);
        EndEncounter.gameObject.SetActive(true);
        InfoMenu.gameObject.SetActive(false);
        Building.gameObject.SetActive(true);
    }

    public void openBuildingMenu()
    {
        Building.gameObject.SetActive(false);
        BuildingMenu.gameObject.SetActive(true);
        EndEncounter.gameObject.SetActive(false);
        Info.gameObject.SetActive(false);
        
    }
    public void closeBuildingMenu()
    {
        Info.gameObject.SetActive(true);
        EndEncounter.gameObject.SetActive(true);
        Building.gameObject.SetActive(true);
        BuildingMenu.gameObject.SetActive(false);
    }
    public void correctoption()
    {
        value = "success";
        conMenu.gameObject.SetActive(true);
        animal.gameObject.SetActive(true);
        closeBuildingMenu();
        Building.gameObject.SetActive(false);
    }
    public void wrongoption()
    {
        value = "fail";
        closeBuildingMenu();
        failmenu.gameObject.SetActive(true);
        Building.gameObject.SetActive(false);
    }
    public void endencounter()
    {
        SceneManager.LoadScene("MainMapView");
    }
    private void OnDisable()
    {
        PlayerPrefs.SetString("value", value);
    }


}
