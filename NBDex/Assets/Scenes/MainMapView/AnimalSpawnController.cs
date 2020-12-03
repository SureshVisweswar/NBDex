using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class AnimalSpawnController : MonoBehaviour
{
    [SerializeField] private LocationProviderFactory locationProvider;
    
    private float nextSpawnActionTime = 0.0f;
    public float period = 10.0f;

    //Spawn Rates
    private double peregrineFalcon = 0.1;

    //Spawn Locations
    private double[] spawnRange = {45.47168826, -66.42745972, 45.23331631, -65.72502136};

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //double locX = locationProvider.CurrentLocation.LatitudeLongitude.x;
        //double locY = locationProvider.CurrentLocation.LatitudeLongitude.y;
    }
}
