using UnityEngine;
using UnityEngine.InputSystem;

namespace _Main._Scripts.Player
{
    public class RotationModule : MonoBehaviour, IModule
    {
        private Vector2 lastMousePosition;

        private Camera mainCamera;

        [Header("Rotation Value")]
        [SerializeField] private Transform RotationComponent;
        [SerializeField] private SpriteRenderer PlayerLeftRight;

        private GunConponent gunC;

        void Start()
        {
            mainCamera = Camera.main;
            gunC = GetComponent<GunConponent>();
        }

        void FixedUpdate()
        {
            lastMousePosition = Mouse.current.position.ReadValue();

            Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(new Vector3(lastMousePosition.x, lastMousePosition.y, 0));
            mouseWorldPosition.z = 0;

            Vector2 direction = (mouseWorldPosition - RotationComponent.position).normalized;

            bool cursorOnLeft = mouseWorldPosition.x < transform.position.x;

            float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            float finalAngle = baseAngle;

            if (cursorOnLeft)
            {
                PlayerLeftRight.flipX = true;
                finalAngle = -baseAngle + 180;
            }
            else
                PlayerLeftRight.flipX = false;

            Vector3 currentRotation = RotationComponent.eulerAngles;

            float angleY = cursorOnLeft ? 180f : 0f;

            RotationComponent.rotation = Quaternion.Euler(currentRotation.x, angleY, finalAngle);
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
}
