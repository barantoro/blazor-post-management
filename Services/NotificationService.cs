using blazor_post_management.Models;

namespace blazor_post_management.Services
{
    public class NotificationService
    {
        public event Action<Post>? OnSave;
        public event Action<Post>? OnDelete;

        public void NotifySave(Post post) => OnSave?.Invoke(post);
        public void NotifyDelete(Post post) => OnDelete?.Invoke(post);
    }
}
