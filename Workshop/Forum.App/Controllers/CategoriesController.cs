namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Views;
    using ForumSystem.Services;

    public class CategoriesController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int
            _COUNT = PAGE_OFFSET + 3;

        private string[] CurrentPageCategories;
        private string[] AllCategoryNames { get; set; }
        private int LastPage => this.AllCategoryNames.Length / (PAGE_OFFSET + 1);
        private bool IsFirstPage => this.CurrentPage == 0;
        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CurrentPage { get; set; }

        private enum Command
        {
            Back = 0,
            ViewCategory = 1,
            PreviousPage = 11,
            NextPage = 12,
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command)index)
            {
                case Command.Back:
                    return MenuState.Back;

                case Command.ViewCategory:
                    return MenuState.OpenCategory;

                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.Rerender;

                case Command.NextPage:
                    this.ChangePage(true);
                    return MenuState.Rerender;

                default:
                    throw new InvalidCommandException();
            }
        }

        private void LoadCategories()
        {
            this.AllCategoryNames = PostService.GetAllCategoryNames();

            this.CurrentPageCategories = this.AllCategoryNames
                    .Skip(this.CurrentPage * PAGE_OFFSET)
                    .Take(PAGE_OFFSET)
                    .ToArray();
        }

        public IView GetView(string userName)
        {
            this.LoadCategories();
            return new CategoriesView(this.CurrentPageCategories, this.IsFirstPage, this.IsLastPage);
        }

        public CategoriesController()
        {
            this.CurrentPage = 0;
            this.LoadCategories();
        }

        private void ChangePage(bool forward)
        {
            this.CurrentPage += forward ? 1 : -1;
            this.LoadCategories();
        }
    }
}