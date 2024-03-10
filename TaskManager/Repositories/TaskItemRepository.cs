namespace TaskManager.Repositories;

using SQLite;
using TaskManager.Models;

public class TaskItemRepository : ITaskItemRepository
{
    private SQLiteAsyncConnection _connection;

    public event EventHandler<TaskItem> OnItemAdded;
    public event EventHandler<TaskItem> OnItemUpdated;

    public async Task AddItemAsync(TaskItem item)
    {
        await CreateConnectionAsync();
        await _connection.InsertAsync(item);
        OnItemAdded?.Invoke(this, item);
    }

    public async Task AddOrUpdateAsync(TaskItem item)
    {
        if (item.Id == 0)
        {
            await AddItemAsync(item);
        }
        else
        {
            await UpdateItemAsync(item);
        }
    }

    public async Task<List<TaskItem>> GetItemsAsync()
    {
        await CreateConnectionAsync();
        return await _connection.Table<TaskItem>().ToListAsync();
    }

    public async Task UpdateItemAsync(TaskItem item)
    {
        await CreateConnectionAsync();
        await _connection.UpdateAsync(item);
        OnItemUpdated?.Invoke(this, item);
    }

    private async Task CreateConnectionAsync()
    {
        if (_connection != null)
        {
            return;
        }

        var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TaskItems.db");
        _connection = new SQLiteAsyncConnection(databasePath);
        await _connection.CreateTableAsync<TaskItem>();

        if (await _connection.Table<TaskItem>().CountAsync() == 0)
        {
            await _connection.InsertAsync(
                new TaskItem () 
                { 
                    Title = "Welcome to TaskManager", 
                    Due = DateTime.Now 
                });
        }
    }
}
