using System.Windows.Input;
using SalfetkaBlog.Models;

namespace SalfetkaBlog.ViewModels
{
    public class EditPostViewModel : ReactiveObject
    {
        private Post _post;

        public EditPostViewModel(Post post)
        {
            Post = post;
            SaveCommand = ReactiveCommand.Create(Save);
            CancelCommand = ReactiveCommand.Create(Cancel);
        }

        public Post Post
        {
            get => _post;
            set => this.RaiseAndSetIfChanged(ref _post, value);
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        
    }
}
