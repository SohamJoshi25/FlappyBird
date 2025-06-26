using UnityEngine;

public class PipeGeneratorScript : MonoBehaviour
{
    public GameObject pipe;
    public float timer;
    public float spawnRate;
    public float minimumY;
    public float maximumY;
    void Start()
    {
        spawnRate = 3f;
        timer = 5;
        minimumY = -13f;
        maximumY = 13f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            CreatePipe();
            timer = 0f;
        }

    }

    private void CreatePipe()
    {
        Instantiate<GameObject>(pipe, new Vector3(transform.position.x, Random.Range(minimumY,maximumY), 0), transform.rotation);
    }
}
