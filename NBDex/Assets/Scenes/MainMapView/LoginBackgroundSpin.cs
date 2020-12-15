using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginBackgroundSpin : MonoBehaviour
{
    [SerializeField] private GameObject backgroundImage;
    private float animationCounter = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationCounter += Time.deltaTime;

        if (animationCounter >= 0.04)
        {
            animationCounter = animationCounter - 0.04f;
            backgroundImage.gameObject.transform.Rotate(0.0f, 0.0f, 0.5f, Space.Self);
        }
    }
}
