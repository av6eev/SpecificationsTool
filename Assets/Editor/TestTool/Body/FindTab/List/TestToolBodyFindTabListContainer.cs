using System.Linq;
using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab.List
{
    public class TestToolBodyFindTabListContainer : IDisposable
    {
        public readonly GroupBox JsonGroupBox;
        public readonly GroupBox ScrObjGroupBox;
        public readonly GroupBox ClassGroupBox;
        
        private readonly VisualElement _blockListRoot;

        public TestToolBodyFindTabListContainer(VisualElement root)
        {
            _blockListRoot = new VisualElement();
            _blockListRoot.AddStyle("body-list");

            JsonGroupBox = new GroupBox("JSON");
            JsonGroupBox.AddStyle("body-list-group");
            var jsonGroupBoxLabel = JsonGroupBox.Children().First(children => children is Label);
            jsonGroupBoxLabel.ClearClassList();
            jsonGroupBoxLabel.AddStyle("body-list-group-title");
            
            ScrObjGroupBox = new GroupBox("ScrObj");
            var scrObjGroupBoxLabel = ScrObjGroupBox.Children().First(children => children is Label);
            scrObjGroupBoxLabel.ClearClassList();
            scrObjGroupBoxLabel.AddStyle("body-list-group-title");
            
            ClassGroupBox = new GroupBox("Class");
            ClassGroupBox.AddStyle("body-list-group");
            var classGroupBoxLabel = ClassGroupBox.Children().First(children => children is Label);
            classGroupBoxLabel.ClearClassList();
            classGroupBoxLabel.AddStyle("body-list-group-title");
            
            _blockListRoot.Add(JsonGroupBox);
            _blockListRoot.Add(ScrObjGroupBox);
            _blockListRoot.Add(ClassGroupBox);
            
            root.Add(_blockListRoot);
        }

        public void Dispose(VisualElement root)
        {
            root.Remove(_blockListRoot);
        }
    }
}