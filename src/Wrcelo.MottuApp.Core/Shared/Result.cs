using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrcelo.VrumApp.Core.Shared
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public bool IsFailure => !IsSuccess;
        public T Value { get; private set; }
        public List<string> Errors { get; private set; }

        private Result(bool isSuccess, T value, List<string> errors)
        {
            IsSuccess = isSuccess;
            Value = value;
            Errors = errors ?? new List<string>();
        }

        public static Result<T> Success(T value) => new Result<T>(true, value, null);

        public static Result<T> Failure(List<string> errors) => new Result<T>(false, default, errors);

        public static Result<T> Failure(string error) => new Result<T>(false, default, new List<string> { error });
    }
}
