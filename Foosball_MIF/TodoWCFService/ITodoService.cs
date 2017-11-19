using System.Collections.Generic;
using System.ServiceModel;
using TodoWCFService.Models;

namespace TodoWCFService
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        List<TodoItem> GetTodoItems();

        [OperationContract]
        void CreateTodoItem(TodoItem item);

        [OperationContract]
        void EditTodoItem(TodoItem item);

        [OperationContract]
        void DeleteTodoItem(string id);

        [OperationContract]
        bool UsernamePatternMatch(string username);

        [OperationContract]
        bool PasswordPatternMatch(string username);

        [OperationContract]
        bool EmailPatternMatch(string username);
    }
}
