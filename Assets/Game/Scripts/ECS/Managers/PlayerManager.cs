using Game.Platforms;
using Game.Player.Components;
using Game.Player.Systems;
using UnityEngine;

namespace Game.ECS
{
    public class PlayerManager : RunMono, ISingleMono
    {
        private readonly GlobalData _data;
        
        private RunSystems _runSystems;
        private RunSystems _fixedRunSystems;
        
        private SingleSystems _singleSystems;

        public PlayerManager(GlobalData data)
        {
            _data = data;
        }
        
        public void Start()
        {
            Init();
            
            var inputSystem = new PlayerInputSystem();
            
            var newPlayer = Object.Instantiate(_data.MoveData.GameObj);
            var moveComponent = new PlayerMoveComponent(newPlayer, _data.MoveData);
            var moveSystem = new PlayerMoveSystem(moveComponent);
            
            var playerComp = new PlayerComponent(new PlayerEffectsSystem(), moveSystem, inputSystem, new CellsGridComponent(_data.CellData.Grid));
            var playerSys = new PlayerSystem(playerComp);
            
            _singleSystems.Add(playerSys);
            _singleSystems.Add(inputSystem); 

            StartSystems();
            
            _runSystems.Add(playerSys);
            _fixedRunSystems.Add(moveSystem);
        }

        private void Init()
        {
            _runSystems = new RunSystems();
            _fixedRunSystems = new RunSystems();
            _singleSystems = new SingleSystems();
        }

        private void StartSystems()
        {
            _singleSystems.Start();
        }

        public override void Update()
        {
            _runSystems.Run();
        }

        public override void FixedUpdate()
        {
            _fixedRunSystems.Run();
        }

        public override void Stop()
        {
            _runSystems.Stop();
            _fixedRunSystems.Stop();
        }

        public override void Continue()
        {
            _runSystems.Continue();
            _fixedRunSystems.Continue();
        }
        
        public void Destroy()
        {
            _runSystems.Destroy();
            _fixedRunSystems.Destroy();
            _singleSystems.Destroy();
        }
    }
}
