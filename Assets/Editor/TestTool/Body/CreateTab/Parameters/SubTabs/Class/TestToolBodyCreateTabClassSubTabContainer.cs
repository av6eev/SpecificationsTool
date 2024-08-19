using Editor.TestTool.Body.CreateTab.Parameters.BaseClass;
using Editor.TestTool.Tabs.SubTabs;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.SubTabs.Class
{
    public class TestToolBodyCreateTabClassSubTabContainer : TestToolSubTabContainer
    {
        public readonly TestToolBodyCreateTabParametersBaseClassContainer BaseClassContainer;
        
        public TestToolBodyCreateTabClassSubTabContainer(VisualElement root) : base(root, "create-tab-sub-tab create-tab-class-sub-tab")
        {
            BaseClassContainer = new TestToolBodyCreateTabParametersBaseClassContainer(Root);
        }

        public override void Dispose(VisualElement root)
        {
            BaseClassContainer.Dispose(Root);
            
            base.Dispose(root);
        }
    }
}