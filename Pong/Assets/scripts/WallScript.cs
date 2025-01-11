using UnityEngine;

public class WallScript : MonoBehaviour
{
    [SerializeField] private BoxCollider2D col;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawCube(transform.position, col.size);
    }
}