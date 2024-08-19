using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.BaseClass
{
    public class TestToolBodyCreateTabParametersBaseClassContainer : IDisposable
    {
        public readonly TextField BaseClassField;
        
        public TestToolBodyCreateTabParametersBaseClassContainer(VisualElement root)
        {
            BaseClassField = new TextField("Base class");
            BaseClassField.AddStyle("create-tab-text-field");
            
            root.Add(BaseClassField);
        }
        
        public void Dispose(VisualElement root)
        {
            root.Remove(BaseClassField);
        }
    }
}