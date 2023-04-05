using Game.Player.Data;
using UnityEngine;

namespace Game.Player.Components
{
    public struct PlayerMoveComponent
    {
        public PlayerMoveComponent(GameObject go, MoveData data)
        {
            Transform = go.transform;
            Rigidbody = go.GetComponent<Rigidbody>();
            Data = data;
        }
        
        public Transform Transform { get; }
        public Rigidbody Rigidbody { get;}
        public MoveData Data { get;}
    }
}