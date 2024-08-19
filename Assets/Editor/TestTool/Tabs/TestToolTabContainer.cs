using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Tabs
{
    public abstract class TestToolTabContainer : IDisposable
    {
        protected TestToolTabContainer(VisualElement root)
        {
        }

        public abstract void Dispose(VisualElement root);
    }
}