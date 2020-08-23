using Zenject;

public class SceneInstall : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Weapons>().FromComponentInChildren();
      Container.Bind<SetDamagePlayerController>().FromComponentInHierarchy().AsSingle();
    }
}
