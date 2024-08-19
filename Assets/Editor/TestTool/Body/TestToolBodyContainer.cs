using Editor.Extensions;
using Editor.TestTool.Body.CreateTab;
using Editor.TestTool.Body.FindTab;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body
{
    public class TestToolBodyContainer
    {
        public TestToolFindTabContainer FindTabContainer;
        public TestToolCreateTabContainer CreateTabContainer;

        public readonly VisualElement Root;
        
        public TestToolBodyContainer(VisualElement root)
        {
            Root = new VisualElement();
            Root.AddStyle("body");

            root.Add(Root);
        }
    }
}