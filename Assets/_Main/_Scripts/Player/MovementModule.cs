using UnityEngine;

public class MovementModule : MonoBehaviour, IModule
{
    [Header("Movement Value")]
    [SerializeField] private float _speed;
    
    [Header("Components")]
    [SerializeField] private Rigidbody2D _rb;
    
    private void Start()
    {
        if (!GlodalInputs.CheckStatus()) GlodalInputs.Init();

        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var direction = GlodalInputs.GetInput().Player.Move.ReadValue<Vector2>();
        _rb.linearVelocity = new Vector2(_speed * direction.x, _speed * direction.y);
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
