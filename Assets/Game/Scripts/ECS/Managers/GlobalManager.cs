using System.Threading;
using System.Threading.Tasks;
using Game.Scripts.Platforms.Systems;
using UnityEngine;

namespace Game.ECS
{
    public class GlobalManager : MonoBehaviour
    {
        [SerializeField] private GlobalData _data;

        private RunSystems _runs;
        private RunSystems _fixedRuns;
        private SingleSystems _singles;
        private TaskSingleSystems _taskSingles;

        private CancellationTokenSource _token;

        private void Awake()
        {
            _runs = new RunSystems();
            _fixedRuns = new RunSystems();
            _singles = new SingleSystems();
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
            _runs.Add(playerManager);
            _fixedRuns.Add(playerManager);
            _singles.Add(playerManager);

            StartSystems();
        }

        private async Task AStartSystems(CancellationToken token)
        {
            await _taskSingles.Start(token);
        }

        private void StartSystems()
        {
            _singles.Start();
        }

        private void Update()
        {
            _runs.Run();
        }

        private void FixedUpdate()
        {
            _fixedRuns.Run();
        }

        private void OnDestroy()
        {
            _runs.Destroy();
            _singles.Destroy();
        }

        private void OnApplicationQuit()
        {
            _token.Cancel();
        }
    }
}