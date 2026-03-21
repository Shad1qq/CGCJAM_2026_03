using UnityEngine;

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

        GlodalInputs.GetInput().Player.Attack.started += i => inHandsGun?.Atack();
        GlodalInputs.GetInput().Player.Attack.canceled += i => inHandsGun?.StopAtack();

    }
    public void SetGun(MasterGun gun)
    {
        Destroy(inHandsGun);
        inHandsGun = Instantiate(gun, parentGun);
    }
}
