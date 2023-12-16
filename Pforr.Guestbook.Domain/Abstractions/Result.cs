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
  public virtual bool IsSuccess { get; }

  [MemberNotNullWhen(true, nameof(Error))]
  public virtual bool IsFailure => !IsSuccess;

  public Error? Error { get; }

  public static Result Success() => new();

  public static Result<TValue> Success<TValue>(TValue value) => new(value);

  public static Result Failure(Error error) => new(error);

  public static Result<TValue> Failure<TValue>(Error error) => new(default, error);
}

public class Result<TValue> : Result
{
  protected internal Result(TValue value) : base() => Value = value;

  protected internal Result(TValue? value, Error error) : base(error) => Value = value;

  [MemberNotNullWhen(true, nameof(Value))]
  public override bool IsSuccess => base.IsSuccess;

  [MemberNotNullWhen(false, nameof(Value))]
  public override bool IsFailure => base.IsFailure;

  public TValue? Value { get; }
}
