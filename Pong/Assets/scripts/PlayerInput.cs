using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject playerRocket;

    private InputAction startAction;
    private InputAction moveAction;

    private void Awake()
    {
        startAction = InputSystem.actions.FindAction("Start");
        moveAction = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        playerRocket.GetComponent<RocketScript>().movement = moveAction.ReadValue<float>();

        if (startAction.WasPressedThisFrame() && gameManager.gameOn == false)
        {
            gameManager.StartGame();
        }
    }
}