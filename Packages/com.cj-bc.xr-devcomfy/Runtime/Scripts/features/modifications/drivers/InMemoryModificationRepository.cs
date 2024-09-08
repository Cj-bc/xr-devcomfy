using System.Collections.Generic;

namespace XRDevcomfy
{
    public class InMemoryModificationRepository : IModificationRepository
    {
        public Stack<PropertyModificationCommand> cmds = new();
        public PropertyModificationCommand Pop() => cmds.Pop();
        public void Push(PropertyModificationCommand cmd)
        {
	    // cmd.property.PropertyType
	    UnityEngine.Debug.Log($"[History pushed] :component {cmd.target} :property {cmd.property.Name} :old {cmd.oldValue} :new {cmd.newValue}");
            cmds.Push(cmd);
        }
    }
}
