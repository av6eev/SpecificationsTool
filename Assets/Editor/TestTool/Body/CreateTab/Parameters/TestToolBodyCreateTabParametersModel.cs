using Editor.TestTool.Body.CreateTab.Parameters.Type;
using Editor.TestTool.Tabs.SubTabs.Collection;
using Reactive.Field;

namespace Editor.TestTool.Body.CreateTab.Parameters
{
    public class TestToolBodyCreateTabParametersModel : TestToolSubTabCollection
    {
        public readonly ReactiveField<TestToolBodyCreateTabParametersType> SelectedType = new(TestToolBodyCreateTabParametersType.Class);
    }
}