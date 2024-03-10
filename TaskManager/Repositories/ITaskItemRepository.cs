namespace TaskManager.Repositories;
using TaskManager.Models;
public interface ITaskItemRepository
{
    event EventHandler<TaskItem> OnItemAdded;
    event EventHandler<TaskItem> OnItemUpdated;
    Task<List<TaskItem>> GetItemsAsync();
    Task AddItemAsync(TaskItem item);
    Task UpdateItemAsync(TaskItem item);
    Task AddOrUpdateAsync(TaskItem item);
}
