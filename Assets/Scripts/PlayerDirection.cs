using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    private Vector3 _direction;

    public Vector3 Direction { get => _direction;}

    void Update()
    {
        GetPlayerDirectionInput();
    }

    private void GetPlayerDirectionInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        _direction = new Vector3(horizontalInput, 0, verticalInput);
    }
}
