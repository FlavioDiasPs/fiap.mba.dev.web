using Fiap.StackOverflow.Infra.Data.Transactions;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.StackOverflow.Api.Controllers.Base
{

    public class ControllerBase : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ControllerBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
