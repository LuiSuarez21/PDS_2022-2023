using BuildMe.Domain.Model;

namespace BuildMe.Test.FakeData
{
    internal class FakeTaskData
    {
        public static List<_Task> GetAllTasks = new List<_Task>()
        {
                new _Task { Id = 0, Description = "Reconstruir duas casas de banho"},
                new _Task { Id = 1, Description = "Reconstruir dois quartos" },
                new _Task { Id = 3, Description = "Cozinha com nova marmore" }
        };
    }
}
