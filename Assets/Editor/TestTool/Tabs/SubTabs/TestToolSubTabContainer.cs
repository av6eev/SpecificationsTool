using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Tabs.SubTabs
{
    public abstract class TestToolSubTabContainer : IDisposable
    {
        public readonly VisualElement Root;
        
        protected TestToolSubTabContainer(VisualElement root, string styles)
        {
            Root = new VisualElement();
            Root.AddStyle(styles);
            
            root.Add(Root);
        }

        public virtual void Dispose(VisualElement root)
        {
            root.Remove(Root);
        }
    }
}