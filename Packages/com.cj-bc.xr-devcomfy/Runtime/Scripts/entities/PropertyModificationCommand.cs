using UnityEngine;
using System.Reflection;

namespace XRDevcomfy
{
    /// Represents one modification procedure. It will be used for recording value diffs
    public struct PropertyModificationCommand<T>
    {
        public Component target { get; private set; }
        public PropertyInfo property { get; private set; }
        public T oldValue { get; private set; }
        public T newValue { get; private set; }

        public PropertyModificationCommand(Component target, PropertyInfo prop, T oldVal, T newVal)
        {
            this.target = target;
            this.property = prop;
            this.oldValue = oldVal;
            this.newValue = newVal;
        }

        public void Execute()
        {
            property.SetValue(target, newValue);
        }

        public void Undo()
        {
            property.SetValue(target, oldValue);
        }
    }

}
