using UnityEngine;

public class Knife : MasterGun
{
    [Header("Components")]
    [SerializeField] private Animator anim;

    public override void Atack()
    {
        anim.SetBool(boolAtackTriger, true);

    }
    public override void StopAtack()
    {
        anim.SetBool(boolAtackTriger, false);

    }

}
