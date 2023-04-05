namespace Game.ECS
{
    public abstract class RunMono
    {
        public virtual void Update(){}
        public virtual void FixedUpdate(){}
        public virtual void LateUpdate(){}
        public abstract void Stop();
        public abstract void Continue();
    }
}