using System.Collections.Generic;
using Presenter;
using UnityEngine.UIElements;

namespace Editor.TestTool.Tabs.SubTabs
{
    public abstract class TestToolSubTabPresenter<T> : PresentersList where T : TestToolSubTabContainer
    {
        protected readonly TestToolContext Context;
        protected readonly TestToolSubTabModel Model;
        protected readonly VisualElement RootContainer;

        protected T Container;

        protected TestToolSubTabPresenter(TestToolContext context, TestToolSubTabModel model, VisualElement rootContainer)
        {
            RootContainer = rootContainer;
            Model = model;
            Context = context;

            InitContainer();

            foreach (var presenter in CreatePresenters())
            {
                Add(presenter);
            }
        }

        public override void Init()
        {
            base.Init();

            Model.OnClose.OnChanged += HandleClose;
        }

        public override void Dispose()
        {
            base.Dispose();

            Container.Dispose(RootContainer);

            Model.OnClose.OnChanged -= HandleClose;
        }

        private void HandleClose()
        {
            Dispose();
        }

        protected abstract void InitContainer();
        protected abstract void AfterInit();
        protected abstract void AfterDispose();
        public abstract override IEnumerable<IPresenter> CreatePresenters();
    }
}
