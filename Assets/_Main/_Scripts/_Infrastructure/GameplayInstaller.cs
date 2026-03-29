using _Main._Scripts.WaveSystem;
using UnityEngine;
using Zenject;
public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<WaveManager>().FromComponentInHierarchy().AsSingle().Lazy();
    }
}
