using Application.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OperationResultService : IOperationResultService
    {
        public OperationResult CreateSuccessResult(string message)
        {
            return new OperationResult
            {
                Success = true,
                Message = message
            };
        }

        public OperationResult CreateFailureResult(string message)
        {
            return new OperationResult
            {
                Success = false,
                Message = message
            };
        }


    }
}
