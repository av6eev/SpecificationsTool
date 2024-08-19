using Editor.Extensions;
using Editor.TestTool.Body;
using Editor.TestTool.Header;
using UnityEditor;
using UnityEngine.UIElements;

namespace Editor.TestTool
{
    public class TestToolContainer
    {
        public readonly TestToolHeaderContainer HeaderContainer;
        public readonly TestToolBodyContainer BodyContainer;
        
        public TestToolContainer(VisualElement root)
        {
            root.styleSheets.Add(AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/TestTool/TestToolStyles.uss"));
            root.AddStyle("root");
            
            HeaderContainer = new TestToolHeaderContainer(root);
            BodyContainer = new TestToolBodyContainer(root);
        }
    }
}