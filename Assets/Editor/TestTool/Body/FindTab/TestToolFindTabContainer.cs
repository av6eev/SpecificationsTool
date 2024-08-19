using Editor.TestTool.Body.FindTab.List;
using Editor.TestTool.Body.FindTab.Title;
using Editor.TestTool.Body.FindTab.Warnings;
using Editor.TestTool.Tabs;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab
{
    public class TestToolFindTabContainer : TestToolTabContainer
    {
        public readonly TestToolBodyFindTabListContainer ListContainer;
        public readonly TestToolBodyFindTabTitleContainer TitleContainer; 
        public readonly TestToolBodyFindTabWarningsContainer WarningsContainer; 
        
        public TestToolFindTabContainer(VisualElement root) : base(root)
        {
            TitleContainer = new TestToolBodyFindTabTitleContainer(root);
            ListContainer = new TestToolBodyFindTabListContainer(root);
            WarningsContainer = new TestToolBodyFindTabWarningsContainer(root);
        }

        public override void Dispose(VisualElement root)
        {
            TitleContainer.Dispose(root);
            ListContainer.Dispose(root);
            WarningsContainer.Dispose(root);
        }
    }
}