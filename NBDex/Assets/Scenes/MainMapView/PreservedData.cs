using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreservedData : MonoBehaviour
{
    private bool sceneReturnState = false;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool getSceneReturnState()
    {
        return sceneReturnState;
    }

    public void setSceneReturnState(bool state)
    {
        sceneReturnState = state;
    }
}
