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

    private float nextSpawnActionTime = 0.0f;
    private float period = 10.0f;

    //Spawn Rates
    private double peregrineFalcon = 0.5;

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
        nextSpawnActionTime += Time.deltaTime;

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
                    if((curLocation.LatitudeLongitude.x > spawnRange[2] && curLocation.LatitudeLongitude.x < spawnRange[0] && curLocation.LatitudeLongitude.y > spawnRange[3] && curLocation.LatitudeLongitude.y < spawnRange[1]) || debugMode) 
                    {
                        if (nextSpawnActionTime >= period)
                        {
                            nextSpawnActionTime = nextSpawnActionTime - period;
                            if(getSpawn(peregrineFalcon))
                            {
                                //Code to spawn falcon
                                print("Spawnin Ducks Babyyyyyyyyyy");
                                Vector3 localPos = LocationProviderFactory.Instance.mapManager.GeoToWorldPosition(curLocation.LatitudeLongitude);
                                Vector3 spawnPos = new Vector3(getSpawnCoord(localPos.x), localPos.y, getSpawnCoord(localPos.z));
                                
                                GameObject newDuck = Instantiate(animals[0], animals[0].transform) as GameObject;
                                newDuck.transform.position = spawnPos;

                            }
                            else
                            {
                                print("Naht Yet");
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
