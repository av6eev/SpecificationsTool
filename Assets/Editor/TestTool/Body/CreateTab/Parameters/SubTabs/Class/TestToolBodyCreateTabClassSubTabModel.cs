using Editor.TestTool.Body.CreateTab.Parameters.BaseClass;
using Editor.TestTool.Tabs.SubTabs;

namespace Editor.TestTool.Body.CreateTab.Parameters.SubTabs.Class
{
    public class TestToolBodyCreateTabClassSubTabModel : TestToolSubTabModel
    {
        public readonly TestToolBodyCreateTabParametersBaseClassModel BaseClassModel = new();
        
        public TestToolBodyCreateTabClassSubTabModel() : base(TestToolSubTabType.BaseClass)
        {
        }
    }
}