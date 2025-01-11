using UnityEngine;

public class RocketAI : MonoBehaviour
{
    [SerializeField] private GameObject aiRocket;
    [SerializeField] private Transform follow;

    private void Update()
    {
        if (follow.position.y > transform.position.y)
        {
            aiRocket.GetComponent<RocketScript>().movement = 1;
        }
        else if (follow.position.y < transform.position.y)
        {
            aiRocket.GetComponent<RocketScript>().movement = -1;
        }
        else 
        {
            aiRocket.GetComponent<RocketScript>().movement = 0;
        }
    }
}