using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RobotDisplay : MonoBehaviour
{
    [SerializeField] private int length = 3;
    [SerializeField] private string loadingText = "Loading";
    [SerializeField] private TextMeshPro textMesh;
    private float timer, loopTime = 0.5f;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            timer = loopTime;
            counter &= 3;
            counter++;
            string dots = "";
            for (int i = 0; i < counter; i++)
            {
                dots += ".";
            }
            textMesh.text = loadingText + dots;
        }
    }
}
