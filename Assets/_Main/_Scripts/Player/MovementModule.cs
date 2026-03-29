using UnityEngine;

namespace _Main._Scripts.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementModule : MonoBehaviour, IModule
    {
        [Header("Movement Value")]
        [SerializeField] private float _speed;
    
        [Header("Components")]
        [SerializeField] private Rigidbody2D _rb;
    
        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();

            if (!GlodalInputs.CheckStatus()) GlodalInputs.Init();
            
            
        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            var direction = GlodalInputs.GetInput().Player.Move.ReadValue<Vector2>();
            _rb.linearVelocity = new Vector2(_speed * direction.x, _speed * direction.y);
        }

        public void Disable()
        {
            this.enabled = false;
        }

        public void Enable()
        {
            this.enabled = true;
        }
        void OnDestroy()
        {
            if(GlodalInputs.CheckStatus())
                GlodalInputs.Remove();
        }
    }
}