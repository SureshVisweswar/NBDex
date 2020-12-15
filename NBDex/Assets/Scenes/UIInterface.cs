using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class UIInterface : MonoBehaviour
{
    [SerializeField] private Button Info;
    [SerializeField] private Button Building;
    [SerializeField] private Button EndEncounter;
    [SerializeField] private GameObject InfoMenu;
    [SerializeField] private GameObject BuildingMenu;

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


}
