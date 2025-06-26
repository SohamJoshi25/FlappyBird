using UnityEngine;

public class PipeScrip : MonoBehaviour
{
    public float movespeed = 8f;
    public float deadZone;

    void Start()
    {
        deadZone = -150f;
        movespeed = 8f;
    }

    void Update()
    {

        if (transform.position.x < deadZone)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            transform.position = transform.position + (Vector3.left * movespeed * Time.deltaTime);
        }

    }
}
