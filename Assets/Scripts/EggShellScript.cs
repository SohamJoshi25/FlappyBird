using UnityEngine;

public class EggShellScript : MonoBehaviour
{
    SpriteRenderer sr;
    public GameObject newBird;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        Time.timeScale = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15 && sr.enabled)
        {
            sr.enabled = false;
            GameObject Bird = Instantiate<GameObject>(newBird, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
            AudioSource birdAudio = Bird.GetComponent<AudioSource>();
            birdAudio.volume = PlayerPrefs.GetFloat("volume", 0.5f);
            birdAudio.playOnAwake = true;
        }
    }
}
