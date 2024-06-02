namespace UnitTests;
using System;
using Xunit;
using ViaEventAssociation.Core.Tools.OperationResult;


public class OperationResultUnitTests
{
    [Fact]
        public void Success_ShouldCreateSuccessfulResult()
        {
            var result = Result.Success();

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailure);
            Assert.Equal(Error.NoError.Code, result.Error.Code);
            Assert.Equal(Error.NoError.Message, result.Error.Message);
        }

        [Fact]
        public void Fail_ShouldCreateFailureResult()
        {
            var error = Error.InternalServerError("Test error");
            var result = Result.Fail(error);

            Assert.False(result.IsSuccess);
            Assert.True(result.IsFailure);
            Assert.Equal(error.Code, result.Error.Code);
            Assert.Equal(error.Message, result.Error.Message);
        }

        [Fact]
        public void ImplicitErrorToResult_ShouldCreateFailureResult()
        {
            var error = Error.InternalServerError("Implicit error");
            Result result = error;

            Assert.False(result.IsSuccess);
            Assert.True(result.IsFailure);
            Assert.Equal(error.Code, result.Error.Code);
            Assert.Equal(error.Message, result.Error.Message);
        }

        [Fact]
        public void ImplicitBoolToResult_ShouldCreateCorrespondingResult()
        {
            Result successResult = true;
            Result failureResult = false;

            Assert.True(successResult.IsSuccess);
            Assert.False(successResult.IsFailure);
            Assert.Equal(Error.NoError.Code, successResult.Error.Code);
            Assert.Equal(Error.NoError.Message, successResult.Error.Message);

            Assert.False(failureResult.IsSuccess);
            Assert.True(failureResult.IsFailure);
            Assert.Equal(Error.InternalServerError().Code, failureResult.Error.Code);
            Assert.Equal(Error.InternalServerError().Message, failureResult.Error.Message);
        }

        [Fact]
        public void OnSuccess_ShouldInvokeActionIfSuccess()
        {
            var result = Result.Success();
            bool actionInvoked = false;

            result.OnSuccess(() => actionInvoked = true);

            Assert.True(actionInvoked);
        }

        [Fact]
        public void OnFailure_ShouldInvokeActionIfFailure()
        {
            var error = Error.InternalServerError("Test error");
            var result = Result.Fail(error);
            bool actionInvoked = false;

            result.OnFailure(() => actionInvoked = true);

            Assert.True(actionInvoked);
        }

        [Fact]
        public void OnSuccess_ShouldThrowArgumentNullExceptionIfActionIsNull()
        {
            var result = Result.Success();

            Assert.Throws<ArgumentNullException>(() => result.OnSuccess(null));
        }

        [Fact]
        public void OnFailure_ShouldThrowArgumentNullExceptionIfActionIsNull()
        {
            var error = Error.InternalServerError("Test error");
            var result = Result.Fail(error);

            Assert.Throws<ArgumentNullException>(() => result.OnFailure(null));
        }
    }

    public class ResultOfTTests
    {
        [Fact]
        public void Success_ShouldCreateSuccessfulResultWithValue()
        {
            var value = "Test value";
            var result = Result<string>.Success(value);

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailure);
            Assert.Equal(value, result.Value);
            Assert.Equal(Error.NoError.Code, result.Error.Code);
            Assert.Equal(Error.NoError.Message, result.Error.Message);
        }

        [Fact]
        public void Fail_ShouldCreateFailureResultWithDefaultValue()
        {
            var error = Error.InternalServerError("Test error");
            var result = Result<string>.Fail(error);

            Assert.False(result.IsSuccess);
            Assert.True(result.IsFailure);
            Assert.Null(result.Value);
            Assert.Equal(error.Code, result.Error.Code);
            Assert.Equal(error.Message, result.Error.Message);
        }

        [Fact]
        public void ImplicitValueToResult_ShouldCreateSuccessfulResult()
        {
            string value = "Implicit value";
            Result<string> result = value;

            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailure);
            Assert.Equal(value, result.Value);
            Assert.Equal(Error.NoError.Code, result.Error.Code);
            Assert.Equal(Error.NoError.Message, result.Error.Message);
        }

        [Fact]
        public void ImplicitErrorToResult_ShouldCreateFailureResult()
        {
            var error = Error.InternalServerError("Implicit error");
            Result<string> result = error;

            Assert.False(result.IsSuccess);
            Assert.True(result.IsFailure);
            Assert.Null(result.Value);
            Assert.Equal(error.Code, result.Error.Code);
            Assert.Equal(error.Message, result.Error.Message);
        }

        [Fact]
        public void OnSuccess_ShouldInvokeActionIfSuccess()
        {
            var value = "Test value";
            var result = Result<string>.Success(value);
            string actionValue = null;

            result.OnSuccess(v => actionValue = v);

            Assert.Equal(value, actionValue);
        }

        [Fact]
        public void OnFailure_ShouldInvokeActionIfFailure()
        {
            var error = Error.InternalServerError("Test error");
            var result = Result<string>.Fail(error);
            Error actionError = null;

            result.OnFailure(e => actionError = e);

            Assert.Equal(error.Code, actionError.Code);
            Assert.Equal(error.Message, actionError.Message);
        }

        [Fact]
        public void OnSuccess_ShouldThrowArgumentNullExceptionIfActionIsNull()
        {
            var result = Result<string>.Success("Test value");

            Assert.Throws<ArgumentNullException>(() => result.OnSuccess(null));
        }

        [Fact]
        public void OnFailure_ShouldThrowArgumentNullExceptionIfActionIsNull()
        {
            var error = Error.InternalServerError("Test error");
            var result = Result<string>.Fail(error);

            Assert.Throws<ArgumentNullException>(() => result.OnFailure(null));
        }
    }
