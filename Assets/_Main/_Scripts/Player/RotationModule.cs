using UnityEngine;
using UnityEngine.InputSystem;

public class RotationModule : MonoBehaviour, IModule
{
    private Vector2 lastMousePosition;

    private Camera mainCamera;

    [Header("Rotation Value")]
    [SerializeField] private Transform RotationComponent;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        lastMousePosition = Mouse.current.position.ReadValue();

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(lastMousePosition.x, lastMousePosition.y, 0));
        mouseWorldPosition.z = 0;

        Vector2 direction = (mouseWorldPosition - RotationComponent.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        RotationComponent.rotation = Quaternion.Euler(0, 0, angle);
    }
    public void Disable()
    {
        this.Disable();
    }

    public void Enable()
    {
        this.Enable();
    }

}
