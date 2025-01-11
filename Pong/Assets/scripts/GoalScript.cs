using UnityEngine;

public class GoalScript : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            if (this.CompareTag("playerGoal"))
            {
                gameManager.StopGame(false);
            }
            else
            {
                gameManager.StopGame(true);
            }
        }
    }
}