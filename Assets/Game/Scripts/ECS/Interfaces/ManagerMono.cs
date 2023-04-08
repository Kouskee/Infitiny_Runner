namespace Game.ECS
{
    public abstract class ManagerMono
    {
        public abstract void Start();
        public virtual void Update(){}
        public virtual void FixedUpdate(){}
        public virtual void LateUpdate(){}
        public virtual void Stop(){}
        public virtual void Continue(){}
        public virtual void Destroy(){}
    }
}