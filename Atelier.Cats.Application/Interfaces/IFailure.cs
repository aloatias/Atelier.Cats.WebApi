using System;

namespace Atelier.Cats.Application.Interfaces
{
    public interface IFailure
    {
        string ErrorMessage { get; }
        Exception Exception { get; }
    }
}
