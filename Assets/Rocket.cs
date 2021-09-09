using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public static Rocket Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance ??= this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
