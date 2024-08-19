using System.Linq;
using Editor.Extensions;
using Editor.TestTool.Utilities;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.Type
{
    public class TestToolBodyCreateTabParametersTypeContainer : IDisposable
    {
        public readonly EnumField TypeField;
        
        public TestToolBodyCreateTabParametersTypeContainer(VisualElement root)
        {
            TypeField = new EnumField("Type", TestToolBodyCreateTabParametersType.Class);
            TypeField.AddStyle("create-tab-enum-field");

            var contentContainer = TypeField.Children().Last();
            contentContainer.AddStyle("create-tab-enum-field-input");
            
            root.Add(TypeField);
        }
        
        public void Dispose(VisualElement root)
        {
            root.Remove(TypeField);
        }
    }
}