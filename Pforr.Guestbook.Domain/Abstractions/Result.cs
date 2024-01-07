using System.Diagnostics.CodeAnalysis;

namespace Pforr.Guestbook.Domain.Abstractions;

public class Result
{
  protected internal Result() => IsSuccess = true;

  protected internal Result(Error error)
  {
    IsSuccess = false;
    Error = error;
  }

  [MemberNotNullWhen(false, nameof(Error))]
  public bool IsSuccess { get; }

  public bool IsFailure => !IsSuccess;

  public Error? Error { get; }

  public static Result Success() => new();

  public static Result<TValue> Success<TValue>(TValue value) => new(value);

  public static Result Failure(Error error) => new(error);

  public static Result<TValue> Failure<TValue>(Error error) => new(error);
}

public class Result<TValue> : Result
{
  protected internal Result(TValue value) : base() => Value = value;

  protected internal Result(Error error) : base(error) { }

  [MemberNotNullWhen(true, nameof(Value))]
  public new bool IsSuccess => base.IsSuccess;

  public TValue? Value { get; }
}
