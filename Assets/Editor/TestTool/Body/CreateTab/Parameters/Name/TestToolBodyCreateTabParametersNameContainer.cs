using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.Name
{
    public class TestToolBodyCreateTabParametersNameContainer : IDisposable
    {
        public readonly TextField NameField;
        
        public TestToolBodyCreateTabParametersNameContainer(VisualElement root)
        {
            NameField = new TextField("Name");
            NameField.AddStyle("create-tab-text-field");
            
            root.Add(NameField);
        }
        
        public void Dispose(VisualElement root)
        {
            root.Remove(NameField);
        }
    }
}