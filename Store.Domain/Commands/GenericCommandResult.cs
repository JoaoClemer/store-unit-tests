using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public GenericCommandResult(bool succes, string message, object data)
        {
            Success = succes;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}