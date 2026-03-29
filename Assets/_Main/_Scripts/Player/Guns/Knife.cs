using UnityEngine;

namespace _Main._Scripts.Player.Guns
{
    public class Knife : MasterGun
    {
        [Header("Components")]
        [SerializeField] private Animator anim;

        public override void Attack()
        {
            anim.SetBool(boolAtackTriger, true);

        }
        public override void StopAttack()
        {
            anim.SetBool(boolAtackTriger, false);

        }

    }
}
