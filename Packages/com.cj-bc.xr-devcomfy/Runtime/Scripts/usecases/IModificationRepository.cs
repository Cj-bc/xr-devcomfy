namespace XRDevcomfy
{
    public interface IModificationRepository
    {
        public PropertyModificationCommand Pop();
        public void Push(PropertyModificationCommand cmd);
    }
}
