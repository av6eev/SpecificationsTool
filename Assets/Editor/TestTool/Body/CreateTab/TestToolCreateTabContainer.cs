using Editor.TestTool.Body.CreateTab.Parameters;
using Editor.TestTool.Body.CreateTab.Title;
using Editor.TestTool.Tabs;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab
{
    public class TestToolCreateTabContainer : TestToolTabContainer
    {
        public readonly TestToolBodyCreateTabTitleContainer TitleContainer;
        public readonly TestToolBodyCreateTabParametersContainer ParametersContainer;

        public TestToolCreateTabContainer(VisualElement root) : base(root)
        {
            TitleContainer = new TestToolBodyCreateTabTitleContainer(root);
            ParametersContainer = new TestToolBodyCreateTabParametersContainer(root);
        }

        public override void Dispose(VisualElement root)
        {
            TitleContainer.Dispose(root);
            ParametersContainer.Dispose(root);
        }
    }
}