using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Title
{
    public class TestToolBodyCreateTabTitleContainer : IDisposable
    {
        private readonly VisualElement _blockTitleRoot;

        public TestToolBodyCreateTabTitleContainer(VisualElement root)
        {
            _blockTitleRoot = new VisualElement();
            _blockTitleRoot.AddStyle("body-title");

            var label = new Label("Setup new specification");
            _blockTitleRoot.Add(label);
            
            root.Add(_blockTitleRoot);
        }
        
        public void Dispose(VisualElement root)
        {
            root.Remove(_blockTitleRoot);   
        }
    }
}