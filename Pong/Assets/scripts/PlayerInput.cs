using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject playerRocket;

    private InputAction startAction;
    private InputAction moveAction;
    private InputAction pauseAction;

    private void Awake()
    {
        startAction = InputSystem.actions.FindAction("Start");
        moveAction = InputSystem.actions.FindAction("Move");
        pauseAction = InputSystem.actions.FindAction("Pause");
    }

    void Update()
    {
        playerRocket.GetComponent<RocketScript>().movement = moveAction.ReadValue<float>();

        if (startAction.WasPressedThisFrame())
        {
            gameManager.StartGame();
        }

        if (pauseAction.WasPressedThisFrame())
        {
            gameManager.Pause();
        }
    }
}