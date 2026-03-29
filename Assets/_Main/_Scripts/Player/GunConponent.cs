using _Main._Scripts.Player.Guns;
using UnityEngine;

namespace _Main._Scripts.Player
{
    public class GunConponent : MonoBehaviour
    {
        private MasterGun inHandsGun;

        [Header("Value")]
        [SerializeField] private Transform parentGun;

        [Header("Tests")]
        public MasterGun prefab;

        private void Start()
        {
            SetGun(prefab);

            if (!GlodalInputs.CheckStatus()) GlodalInputs.Init();

            GlodalInputs.GetInput().Player.Attack.started += i => inHandsGun?.Attack();
            GlodalInputs.GetInput().Player.Attack.canceled += i => inHandsGun?.StopAttack();

        }
        public MasterGun GetGun()
        {
            return inHandsGun;
        }
        public Transform GetGunParent()
        {
            return parentGun;
        }

        public void SetGun(MasterGun gun)
        {
            Destroy(inHandsGun);
            inHandsGun = Instantiate(gun, parentGun);
        }
    }
}
