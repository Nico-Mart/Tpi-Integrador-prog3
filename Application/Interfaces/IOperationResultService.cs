using Application.Common;


namespace Application.Interfaces
{
    public interface IOperationResultService
    {
        OperationResult CreateSuccessResult(string message);
        OperationResult CreateFailureResult(string message);
    }
}
