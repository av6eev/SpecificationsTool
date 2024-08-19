using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab.Title
{
    public class TestToolBodyFindTabTitleContainer : IDisposable
    {
        private readonly VisualElement _blockTitleRoot;

        public TestToolBodyFindTabTitleContainer(VisualElement root)
        {
            _blockTitleRoot = new VisualElement();
            _blockTitleRoot.AddStyle("body-title");

            var label = new Label("Current specification names");
            _blockTitleRoot.Add(label);
            
            root.Add(_blockTitleRoot);
        }

        public void Dispose(VisualElement root)
        {
            root.Remove(_blockTitleRoot);
        }
    }
}