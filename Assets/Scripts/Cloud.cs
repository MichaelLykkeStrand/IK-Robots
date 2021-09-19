using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Cloud : MonoBehaviour
{
    private CloudController cloudController;
    private Transform target;
    [SerializeField] private float spawnTime = 2f;
    [SerializeField] private Vector3 originalScale;
    [SerializeField] private bool preWarm = false;
    private bool spawning = true;
    private bool deSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        transform.localScale = new Vector3(0,0,0);
        cloudController = CloudController.instance;
        target = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            transform.DOScale(originalScale, spawnTime);
            spawning = false;
            /*
            Color color = GetComponent<MeshRenderer>().material.color;
            color.a = 0.1f;
            GetComponent<MeshRenderer>().material.color = new Color(color.r,color.g,color.b,color.a);
            */
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < cloudController.DespawnDistance)
        {
            Vector3 windVector = cloudController.Windspeed;
            Vector3 correctedWindVector = new Vector3(windVector.x, 0,windVector.y);
            transform.position += correctedWindVector * Time.deltaTime;
        }
        else
        {
            if (!deSpawning)
            {
                deSpawning = true;
                transform.DOScale(0, spawnTime).OnComplete(() => {
                    cloudController.Remove(this.gameObject);
                    Destroy(this.gameObject);
                });
            }
        }
    }
}