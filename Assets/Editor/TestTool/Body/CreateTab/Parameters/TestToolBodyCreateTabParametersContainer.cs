using Editor.TestTool.Body.CreateTab.Parameters.Name;
using Editor.TestTool.Body.CreateTab.Parameters.Type;
using Editor.TestTool.Tabs.SubTabs.Collection;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters
{
    public class TestToolBodyCreateTabParametersContainer : TestToolSubTabCollectionContainer
    {
        public readonly TestToolBodyCreateTabParametersNameContainer NameContainer;
        public readonly TestToolBodyCreateTabParametersTypeContainer TypeContainer;
        
        public TestToolBodyCreateTabParametersContainer(VisualElement root) : base(root, "create-tab-parameters")
        {
            NameContainer = new TestToolBodyCreateTabParametersNameContainer(Root);
            TypeContainer = new TestToolBodyCreateTabParametersTypeContainer(Root);
        }

        public override void Dispose(VisualElement root)
        {
            NameContainer.Dispose(Root);
            TypeContainer.Dispose(Root);
            
            base.Dispose(root);
        }
    }
}