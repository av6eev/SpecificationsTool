using System.Collections.Generic;
using Editor.TestTool.Body.CreateTab.Parameters.BaseClass;
using Editor.TestTool.Tabs.SubTabs;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab.Parameters.SubTabs.Class
{
    public class TestToolBodyCreateTabClassSubTabPresenter : TestToolSubTabPresenter<TestToolBodyCreateTabClassSubTabContainer>
    {
        public TestToolBodyCreateTabClassSubTabPresenter(TestToolContext context, TestToolSubTabModel model, VisualElement rootContainer) : base(context, model, rootContainer)
        {
        }

        protected override void InitContainer()
        {
            Container = new TestToolBodyCreateTabClassSubTabContainer(RootContainer);
        }

        protected override void AfterInit()
        {
        }

        protected override void AfterDispose()
        {
        }

        public override IEnumerable<IPresenter> CreatePresenters()
        {
            yield return new TestToolBodyCreateTabParametersBaseClassPresenter(Context, ((TestToolBodyCreateTabClassSubTabModel)Model).BaseClassModel, Container.BaseClassContainer);
        }
    }
}