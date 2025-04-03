//using ApiPlatform.Kernel.Core.Utils;

using ApiPlatform.Kernel.Core.Utils;
using Microsoft.Extensions.Options;

namespace ApiPlatform.Kernel.Core.Results;

public interface IApplicationResult<T>
{
    Option<T> Result { get; }
}

public interface IApplicationResult;

public record ApplicationResult<T> : IApplicationResult<T>
{
    public Option<T> Result { get; }

    public ApplicationResult(T result)
    {
        Result = Option<T>.Some(result);
    }
}

public static class ApplicationResult
{
    public static IApplicationResult<T> Success<T>(T result) => new ApplicationResult<T>(result);
}


//public interface IApplicationResult<out T>
//{
//    // Your interface members here
//}

//public interface IApplicationResult : IApplicationResult<Dummy>
//{
//    // You can add additional members specific to IApplicationResult here
//}

//public record Dummy
//{
//    // Properties and methods of the Dummy record
//}

//public static class ApplicationResultHelper
//{
//    public static IApplicationResult Success() => new ApplicationResult<Dummy>();
//}

//public class ExampleClass
//{
//    public IApplicationResult GetResult()
//    {
//        // Use the helper method to create an instance of IApplicationResult<Dummy>
//        return ApplicationResultHelper.Success();
//    }
//}

//public class ApplicationResult<T> : IApplicationResult<T>, IApplicationResult
//{
//    // Implementation of IApplicationResult<T> members
//}


//public interface IApplicationResult<out T>
//{
//    //IApplicationMessages Messages { get; }

//    //IOption<T> Result { get; }
//}

//public record NoContentResult;

//public interface IApplicationResult : IApplicationResult<NoContentResult>;

//public static class ApplicationResultHelper
//{
//    public static IApplicationResult Success()
//    {
//        return new ApplicationResult<NoContentResult>();
//    }
//}

//public class ApplicationResult<T> : IApplicationResult<T>
//{
//    // Implementation of IApplicationResult<T> members

//    // Explicit conversion operator from ApplicationResult<T> to IApplicationResult<T>
//    public static explicit operator IApplicationResult<T>(ApplicationResult<T> result)
//    {
//        // You might want to add any necessary logic here
//        return result;
//    }
//}


//public record ApplicationResult<T> : IApplicationResult<T>
//{
//    public IApplicationMessages Messages { get; }

//    public IOption<T> Result { get; }

//    public ApplicationResult()
//    {
//        Messages = ApplicationMessages.Empty();
//        Result = Option<T>.None;
//    }

//    private ApplicationResult(IApplicationMessages messages)
//    {
//        Messages = messages;
//        Result = Option<T>.None;
//    }

//    private ApplicationResult(T result) : this(ApplicationMessages.Empty())
//    {
//        Result = Option<T>.Some(result);
//    }

//    public static IApplicationResult<T> Success(T result) => new ApplicationResult<T>(result);

//    public static IApplicationResult<T> Failed(string message)
//    {
//        var messages = ApplicationMessages.Empty().Add(message);
//        return new ApplicationResult<T>(messages);
//    }

//    public static explicit operator NoContentApplicationResult(IApplicationResult<T> result)
//    {
//        // You might want to add any necessary logic here
//        //return result;
//        throw new NotImplementedException();
//    }

//}

//public record NoContentApplicationResult : IAppl


////public record NoContentApplicationResult // : IApplicationResult<NoContentResult>
////{
////    //public static IApplicationResult Success()
////    //{
////    //    return ApplicationResult<NoContentResult>.Success(new NoContentResult());
////    //}

////    //public static new IApplicationResult Failed(string message)
////    //{
////    //    return ApplicationResult<NoContentResult>.Failed(message);
////    //}
////    //public IApplicationMessages Messages => throw new NotImplementedException();

////    //public IOption<NoContentResult> Result => throw new NotImplementedException();

////    //public static IApplicationResult Success()
////    //{
////    //    var r = ApplicationResult<NoContentResult>.Success(new NoContentResult());
////    //    return r;
////    //}

////    //public static IApplicationResult<T> Failed(string message)
////    //{
////    //    var messages = ApplicationMessages.Empty().Add(message);
////    //    return new ApplicationResult<T>(messages);
////    //}

////}
