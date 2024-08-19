using UnityEngine.UIElements;

namespace Editor.TestTool.Utilities
{
    public interface IDisposable
    {
        void Dispose(VisualElement root);
    }
}