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
        Health health = GetComponent<Health>();
        originalScale = transform.localScale;
        transform.localScale = new Vector3(0,0,0);
        cloudController = CloudController.instance;
        target = Camera.main.transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spawning)
        {
            transform.DOScale(originalScale, spawnTime);
            spawning = false;
        }
        float distance = Vector3.Distance(transform.position, target.position);
        if(distance < cloudController.DespawnDistance)
        {
            Vector3 windVector = cloudController.Windspeed;
            Vector3 correctedWindVector = new Vector3(windVector.x, 0,windVector.y);
            transform.position += correctedWindVector * Time.fixedDeltaTime;
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
