using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Utils;

public class AnimalSpawnController : MonoBehaviour
{
    private bool debugMode = true;
    private AbstractLocationProvider _locationProvider = null;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] animals;

    //Spawn Timers
    private float nextSpawnWolf = 0.0f;
    private float nextSpawnEagle = 0.0f;
    private float nextSpawnMallard = 0.0f;
    private float nextSpawnDeer = 0.0f;

    //Spawn Trigger Periods
    private float spawnPeriodWolf = 1500.0f;
    private float spawnPeriodEagle = 300.0f;
    private float spawnPeriodMallard = 45.0f;
    private float spawnPeriodDeer = 120.0f;

    //Spawn Rates
    private double wolfRate = 0.01;
    private double eagleRate = 0.05;
    private double mallardRate = 0.3;
    private double deerRate = 0.25;

    //Spawn Locations
    private double[] spawnRange = {45.47168826, -66.42745972, 45.23331631, -65.72502136};

    // Start is called before the first frame update
    void Start()
    {
        if (_locationProvider == null)
		{
			_locationProvider = LocationProviderFactory.Instance.DefaultLocationProvider as AbstractLocationProvider;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Location curLocation = _locationProvider.CurrentLocation;
        nextSpawnWolf += Time.deltaTime;
        nextSpawnEagle += Time.deltaTime;
        nextSpawnMallard += Time.deltaTime;
        nextSpawnDeer += Time.deltaTime;

        if (!curLocation.IsLocationServiceInitializing)
        {
            if(!curLocation.IsLocationServiceEnabled)
            {
                Debug.Log("Location services not enabled");
            }
            else
            {
                if (curLocation.LatitudeLongitude.Equals(Vector2d.zero))
                {
                    Debug.Log("Waiting for location ....");
                }
                else
                {
                    if ((curLocation.LatitudeLongitude.x > spawnRange[2] && curLocation.LatitudeLongitude.x < spawnRange[0] && curLocation.LatitudeLongitude.y > spawnRange[3] && curLocation.LatitudeLongitude.y < spawnRange[1]) || debugMode) 
                    {
                        if (nextSpawnWolf >= spawnPeriodWolf) 
                        {
                            nextSpawnWolf = nextSpawnWolf - spawnPeriodWolf;

                            if (getSpawn(wolfRate))
                            {
                                print("Spawnin Wolves Babyyyyyyyyyy");

                                Vector3 localPos = LocationProviderFactory.Instance.mapManager.GeoToWorldPosition(curLocation.LatitudeLongitude);
                                Vector3 spawnPos = new Vector3(getSpawnCoord(localPos.x), localPos.y, getSpawnCoord(localPos.z));

                                GameObject newWolf = Instantiate(animals[3], animals[3].transform) as GameObject;
                                newWolf.transform.position = spawnPos;

                                var euler = newWolf.transform.eulerAngles;
                                euler.z = Random.Range(0.0f, 360.0f);
                                newWolf.transform.eulerAngles = euler;
                            }
                            else
                            {
                                print("Naht Yet Wolf");
                            }
                        }

                        if (nextSpawnEagle >= spawnPeriodEagle)
                        {
                            nextSpawnEagle = nextSpawnEagle - spawnPeriodEagle;

                            if (getSpawn(eagleRate))
                            {
                                print("Spawnin Eagles Babyyyyyyyyyy");

                                Vector3 localPos = LocationProviderFactory.Instance.mapManager.GeoToWorldPosition(curLocation.LatitudeLongitude);
                                Vector3 spawnPos = new Vector3(getSpawnCoord(localPos.x), localPos.y, getSpawnCoord(localPos.z));

                                GameObject newEagle = Instantiate(animals[2], animals[2].transform) as GameObject;
                                newEagle.transform.position = spawnPos;

                                var euler = newEagle.transform.eulerAngles;
                                euler.z = Random.Range(0.0f, 360.0f);
                                newEagle.transform.eulerAngles = euler;
                            }
                            else
                            {
                                print("Naht Yet Eagle");
                            }
                        }

                        if (nextSpawnMallard >= spawnPeriodMallard)
                        {
                            nextSpawnMallard = nextSpawnMallard - spawnPeriodMallard;

                            if (getSpawn(mallardRate))
                            {
                                print("Spawnin Ducks Babyyyyyyyyyy");

                                Vector3 localPos = LocationProviderFactory.Instance.mapManager.GeoToWorldPosition(curLocation.LatitudeLongitude);
                                Vector3 spawnPos = new Vector3(getSpawnCoord(localPos.x), localPos.y, getSpawnCoord(localPos.z));

                                GameObject newMallard = Instantiate(animals[0], animals[0].transform) as GameObject;
                                newMallard.transform.position = spawnPos;

                                var euler = newMallard.transform.eulerAngles;
                                euler.z = Random.Range(0.0f, 360.0f);
                                newMallard.transform.eulerAngles = euler;
                            }
                            else
                            {
                                print("Naht Yet Mallard");
                            }
                        }

                        if (nextSpawnDeer >= spawnPeriodDeer)
                        {
                            nextSpawnDeer = nextSpawnDeer - spawnPeriodDeer;

                            if (getSpawn(deerRate))
                            {
                                print("Spawnin Deer Babyyyyyyyyyy");

                                Vector3 localPos = LocationProviderFactory.Instance.mapManager.GeoToWorldPosition(curLocation.LatitudeLongitude);
                                Vector3 spawnPos = new Vector3(getSpawnCoord(localPos.x), localPos.y, getSpawnCoord(localPos.z));

                                GameObject newDeer = Instantiate(animals[1], animals[1].transform) as GameObject;
                                newDeer.transform.position = spawnPos;

                                var euler = newDeer.transform.eulerAngles;
                                euler.z = Random.Range(0.0f, 360.0f);
                                newDeer.transform.eulerAngles = euler;
                            }
                            else
                            {
                                print("Naht Yet Deer");
                            }
                        }
                    }
                }
            }
        }
    }

    private float getSpawnCoord(float coord)
    {
        System.Random rng = new System.Random();

        return (float)((Random.Range(0,2) * 2 - 1) * rng.Next((int)(coord + 10), (int)(coord + 20)));
    }

    private bool getSpawn(double probability) 
    {
        int intProb = (int)(probability * 100);
        System.Random rng = new System.Random();

        return rng.Next(100) <= intProb;
    }
}
