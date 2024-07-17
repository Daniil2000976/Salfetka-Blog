using System.Collections.ObjectModel;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using SalfetkaBlog.Models;
using SalfetkaBlog.Controllers;

namespace SalfetkaBlog.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private PostController _postController;
        private Post _selectedPost;

        public MainWindowViewModel()
        {
            _postController = new PostController();
            Posts = _postController.Posts;
            AddCommand = ReactiveCommand.Create(AddPost);
            EditCommand = ReactiveCommand.Create(EditPost);
            DeleteCommand = ReactiveCommand.Create(DeletePost);
        }

        public ObservableCollection<Post> Posts { get; }

        public Post SelectedPost
        {
            get => _selectedPost;
            set => this.RaiseAndSetIfChanged(ref _selectedPost, value);
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        private void AddPost()
        {
            var post = new Post { Id = Posts.Count + 1 };
            var editWindow = new EditPostWindow { DataContext = new EditPostViewModel(post) };
            editWindow.ShowDialog();
            if (!string.IsNullOrWhiteSpace(post.Title) && !string.IsNullOrWhiteSpace(post.Content))
            {
                _postController.AddPost(post);
            }
        }

        private void EditPost()
        {
            var editWindow = new EditPostWindow { DataContext = new EditPostViewModel(SelectedPost) };
            editWindow.ShowDialog();
            _postController.EditPost(SelectedPost);
        }

        private void DeletePost()
        {
            _postController.DeletePost(SelectedPost.Id);
        }
    }
}
