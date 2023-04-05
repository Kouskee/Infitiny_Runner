using System.Threading;
using System.Threading.Tasks;
using Game.ECS;
using Game.Platforms.Data;
using UnityEngine;

namespace Game.Scripts.Platforms.Systems
{
    public class CellsSpawnSystem : ITaskSingleMono
    {
        private readonly CellData _data;
        private readonly Transform _parent;

        public CellsSpawnSystem(CellData data, Transform parent)
        {
            _data = data;
            _parent = parent;
        }

        public async Task Start(CancellationToken token)
        {
            for (int x = 0; x < _data.Grid.Length; x++)
            {
                for (int y = 0; y < _data.Grid[x].Length; y++)
                {
                    var pos = new Vector3(y * 20, 0, x * 20);
                    try
                    {
                        switch (_data.Grid[x][y].TypeCell)
                        {
                            case TypeCell.Platform:
                                await SpawnPlatform(_data.Platform, _parent, pos, token);
                                break;
                            case TypeCell.Wall:
                                await SpawnPlatform(_data.Wall, _parent, pos, token);
                                break;
                        }
                    }
                    catch(TaskCanceledException) { }
                }
            }
        }
        
        private async Task SpawnPlatform(GameObject go, Transform parent,  Vector3 position, CancellationToken token)
        {
            Object.Instantiate(go, position, Quaternion.identity, parent);
            await Task.Delay(200, token);
        }
        
        public void Destroy() { }
    }
}