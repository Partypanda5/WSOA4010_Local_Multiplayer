using UnityEngine;
using UnityEngine.InputSystem;

public class SplitScreenManager : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    void Start()
    {
        PlayerInput.Instantiate(playerOne);
        
        PlayerInput.Instantiate(playerTwo);
    }

    void Update()
    {
        
    }
}
