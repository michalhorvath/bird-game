using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    void Awake() {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnApplicationFocus(bool hasFocus){
        print("has focus: " + hasFocus);
    }
}
