using Game.Platforms;
using Game.Player.Systems;

namespace Game.Player.Components
{
    public struct PlayerComponent
    {
        public PlayerComponent(PlayerEffectsSystem effectsSystem, PlayerMoveSystem moveSystem, PlayerInputSystem inputSystem, CellsGridComponent gridComponent)
        {
            EffectsSystem = effectsSystem;
            MoveSystem = moveSystem;
            InputSystem = inputSystem;
            GridComponent = gridComponent;
        }

        public PlayerEffectsSystem EffectsSystem { get; }
        public PlayerMoveSystem MoveSystem { get; }
        public PlayerInputSystem InputSystem { get; }
        public CellsGridComponent GridComponent { get; }
    }
}