using System;

namespace Atelier.Cats.Application.Abstractions.Models
{
    public interface IFailure
    {
        string ErrorMessage { get; }
        Exception Exception { get; }
    }
}
