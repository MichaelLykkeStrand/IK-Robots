using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    [SerializeField] private Vector2 windspeed;
    [SerializeField] private int cloundAmount = 30;
    [SerializeField] private float height = 120f;
    [SerializeField] private  float despawnDistance = 100f;
    [SerializeField] private GameObject[] cloudPrefabs;
    [SerializeField] private float heightVariance = 35f;
    private Transform origin;
    private List<GameObject> clouds = new List<GameObject>();
    public static CloudController instance;

    public Vector2 Windspeed { get => windspeed;}
    public float DespawnDistance { get => despawnDistance;}
    public float Height { get => height;}

    // Start is called before the first frame update
    void Awake()
    {
        instance ??= this;
        origin = Camera.main.transform;
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    // Update is called once per frame
    void Update()
    {
        while (clouds.Count < cloundAmount)
        {
            SpawnCloud();
        }
    }

    void SpawnCloud()
    {
        float x = Random.Range(-despawnDistance, despawnDistance)/ 1.4f;
        float y = Random.Range(height-heightVariance, height + heightVariance);
        float z = Random.Range(-despawnDistance, despawnDistance)/ 1.4f;

        x = x + origin.position.x;
        z = z + origin.position.z;


        int prefabIndex = UnityEngine.Random.Range(0, cloudPrefabs.Length);
        GameObject cloud = Instantiate(cloudPrefabs[prefabIndex], new Vector3(x, y, z), Quaternion.identity);
        clouds.Add(cloud);
    }

    public void Remove(GameObject cloud)
    {
        clouds.Remove(cloud);
    }
}
