using System.Linq;
using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab.Warnings
{
    public class TestToolBodyFindTabWarningsContainer : IDisposable
    {
        public readonly GroupBox GroupBox;
        
        private readonly VisualElement _blockWarningsRoot;

        public TestToolBodyFindTabWarningsContainer(VisualElement root)
        {
            _blockWarningsRoot = new VisualElement();
            _blockWarningsRoot.AddStyle("body-warnings");

            GroupBox = new GroupBox("Warnings");
            GroupBox.AddStyle("body-warnings-group");
            var classGroupBoxLabel = GroupBox.Children().First(children => children is Label);
            classGroupBoxLabel.ClearClassList();
            classGroupBoxLabel.AddStyle("body-warnings-group-title");
            
            _blockWarningsRoot.Add(GroupBox);
            
            root.Add(_blockWarningsRoot);
        }

        public void Dispose(VisualElement root)
        {
            root.Remove(_blockWarningsRoot);
        }
    }
}