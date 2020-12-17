using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalClick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                if (hit.transform)
                {
                    if (hit.transform.gameObject.name == "Duck(Clone)")
                    {
                        Destroy(hit.transform.gameObject);
                        PlayerPrefs.SetString("sceneEntered", "Duck");
                        SceneManager.LoadScene("Duck");
                    }
                    else if (hit.transform.gameObject.name == "Deer(Clone)") { 
                        //Nothing here yet
                    }
                    else if (hit.transform.gameObject.name == "Eagle(Clone)")
                    {
                        Destroy(hit.transform.gameObject);
                        bool sceneSelect = (Random.Range(0, 2) == 0);

                        if (sceneSelect)
                        {
                            PlayerPrefs.SetString("sceneEntered", "Eagle1");
                            SceneManager.LoadScene("Eagle1");
                        }
                        else {
                            PlayerPrefs.SetString("sceneEntered", "Eagle2");
                            SceneManager.LoadScene("Eagle2");
                        }
                    }
                    else if (hit.transform.gameObject.name == "Wolf(Clone)")
                    {
                        Destroy(hit.transform.gameObject);
                        PlayerPrefs.SetString("sceneEntered", "Wolf");
                        SceneManager.LoadScene("Wolf");
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }
}
