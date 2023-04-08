using System.Threading;
using System.Threading.Tasks;
using Game.Scripts.Platforms.Systems;
using UnityEngine;

namespace Game.ECS
{
    public class GlobalManager : MonoBehaviour
    {
        [SerializeField] private GlobalData _data;

        private ManagerSystems _managers;
        private TaskSingleSystems _taskSingles;

        private CancellationTokenSource _token;

        private void Awake()
        {
            _managers = new ManagerSystems();
            _taskSingles = new TaskSingleSystems();

            _token = new CancellationTokenSource();
        }

        private async void Start()
        {
            var parentCells = Instantiate(_data.CellData.Parent);
            _taskSingles.Add(new CellsSpawnSystem(_data.CellData, parentCells.transform));
            
            await AStartSystems(_token.Token);
            if (_token.IsCancellationRequested) return;

            var playerManager = new PlayerManager(_data);
            _managers.Add(playerManager);

            StartSystems();
        }

        private async Task AStartSystems(CancellationToken token)
        {
            await _taskSingles.Start(token);
        }

        private void StartSystems()
        {
            _managers.Start();
        }

        private void Update()
        {
            _managers.Run();
        }

        private void FixedUpdate()
        {
            _managers.FixedRun();
        }

        private void OnDestroy()
        {
            _managers.Destroy();
        }

        private void OnApplicationQuit()
        {
            _token.Cancel();
        }
    }
}