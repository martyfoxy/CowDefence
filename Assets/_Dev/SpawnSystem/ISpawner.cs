namespace Game.SpawnSystem
{
    public interface ISpawner<TView, in TData>
    {
        TView Spawn(SpawnPoint spawnPoint, TData data);
    }
}