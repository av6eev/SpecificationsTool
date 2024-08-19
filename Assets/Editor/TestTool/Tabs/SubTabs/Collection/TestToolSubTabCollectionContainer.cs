using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Tabs.SubTabs.Collection
{
    public abstract class TestToolSubTabCollectionContainer : IDisposable
    {
        public readonly VisualElement Root;

        protected TestToolSubTabCollectionContainer(VisualElement root, string styles)
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