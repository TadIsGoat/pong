using UnityEngine;

public class RocketScript : MonoBehaviour
{
    [SerializeField][Tooltip("Only requiered for ai")] private Transform follow;
    [SerializeField][Range(1f, 40f)][Tooltip("The speeeeeeeeed")] private float speed = 1f;
    private BoxCollider2D col;
    public Vector2 spawnPos { get; private set; }
    [HideInInspector] public float movement;
    

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        spawnPos = transform.position;
    }

    private void Update()
    {
        Vector2 newPos;

        if (follow != null)
        {
            newPos = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, follow.position.y, speed * Time.deltaTime));
        }
        else
        {
            newPos = new Vector2(transform.position.x, transform.position.y + movement * speed * Time.deltaTime);
        }

        newPos.y = Mathf.Clamp(newPos.y, -5.1f + (col.size.y * transform.localScale.y / 2), 5.25f - (col.size.y * transform.localScale.y / 2));

        transform.position = newPos;
    }
}