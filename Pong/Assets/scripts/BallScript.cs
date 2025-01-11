using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch()
    {
        float rnd = Random.Range(-1f, 1f);
        rb.AddForce(new Vector2(-1f, rnd), ForceMode2D.Impulse);
    }
}