using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StartBirdScript : MonoBehaviour
{

    void Start()
    {
        Invoke(nameof(Fly), 1.5f);
    }

    [ContextMenu("Bird FLy")]
    public void Fly()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(45,32);

    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > 50)
        {
            StartGame();
        }
    }
}
