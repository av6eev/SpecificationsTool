using System.Collections.Generic;
using Editor.TestTool.Body.FindTab.List;
using Editor.TestTool.Body.FindTab.Title;
using Editor.TestTool.Body.FindTab.Warnings;
using Editor.TestTool.Tabs;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Body.FindTab
{
    public class TestToolFindTabPresenter : TestToolTabPresenter<TestToolFindTabContainer>
    {
        public TestToolFindTabPresenter(TestToolContext context, TestToolTabModel model, VisualElement rootContainer) : base(context, model, rootContainer)
        {
        }

        protected override void InitContainer()
        {
            Container = new TestToolFindTabContainer(RootContainer);
        }

        protected override void AfterInit()
        {
        }

        protected override void AfterDispose()
        {
        }

        public override IEnumerable<IPresenter> CreatePresenters()
        {
            yield return new TestToolBodyFindTabTitlePresenter(Context, Container.TitleContainer);
            yield return new TestToolBodyFindTabListPresenter(Context, Container.ListContainer);
            yield return new TestToolBodyFindTabWarningsPresenter(Context, Container.WarningsContainer);
        }
    }
}