using System.Collections.Generic;
using Editor.TestTool.Body.CreateTab.Parameters;
using Editor.TestTool.Body.CreateTab.Title;
using Editor.TestTool.Tabs;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.CreateTab
{
    public class TestToolCreateTabPresenter : TestToolTabPresenter<TestToolCreateTabContainer>
    {
        public TestToolCreateTabPresenter(TestToolContext context, TestToolTabModel model, VisualElement rootContainer) : base(context, model, rootContainer)
        { 
        }

        protected override void InitContainer()
        {
            Container = new TestToolCreateTabContainer(RootContainer);
        }

        protected override void AfterInit()
        {
        }

        protected override void AfterDispose()
        {
        }

        public override IEnumerable<IPresenter> CreatePresenters()
        {
            yield return new TestToolBodyCreateTabTitlePresenter(Context, Container.TitleContainer);
            yield return new TestToolBodyCreateTabParametersPresenter(Context, new TestToolBodyCreateTabParametersModel(), Container.ParametersContainer);
        }
    }
}