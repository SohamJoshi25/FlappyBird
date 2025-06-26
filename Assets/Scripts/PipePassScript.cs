using UnityEngine;

public class PipePassScript : MonoBehaviour
{
    public LogicScript logicScript;
    public BirdScript birdScript;
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bird" && !logicScript.isGameOver)
        {
            logicScript.AddScore(1);
            logicScript.PointSound();
            birdScript.IncreaseSize(1.01f);
        }
    }
}
