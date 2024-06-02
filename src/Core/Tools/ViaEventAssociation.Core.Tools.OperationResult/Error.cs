namespace ViaEventAssociation.Core.Tools.OperationResult;

public class Error
{
    public ErrorCode Code { get; init; }
    public string Message { get; set; }
    
    private Error(ErrorCode code, string message)
    {
        Code = code;
        Message = message;
    }
    
    public static Error BadRequest(string message = "Bad Request") => new(ErrorCode.BadRequest, message);
    public static Error Unauthorized(string message = "Unauthorized") => new(ErrorCode.Unauthorized, message);
    public static Error Forbidden(string message = "Forbidden") => new(ErrorCode.Forbidden, message);
    public static Error NotFound(string message = "Not Found") => new(ErrorCode.NotFound, message);
    public static Error Teapot(string message = "I'm a teapot") => new(ErrorCode.Teapot, message);
    public static Error InternalServerError(string message = "Internal Server Error") => new(ErrorCode.InternalServerError, message);
    
    public static Error EventNotFound(string message = "Event not found") => new(ErrorCode.EventNotFound, message);
    public static Error EventAlreadyActive(string message = "Event is already active") => new(ErrorCode.EventAlreadyActive, message);
    public static Error EventNotReady(string message = "Event is not ready") => new(ErrorCode.EventNotReady, message);
    public static Error EventFull(string message = "Event is full") => new(ErrorCode.EventFull, message);
    public static Error EventAlreadyExists(string message = "Event already exists") => new(ErrorCode.EventAlreadyExists, message);
    
    public static Error UserNotFound(string message = "User not found") => new(ErrorCode.UserNotFound, message);
    public static Error UserAlreadyExists(string message = "User already exists") => new(ErrorCode.UserAlreadyExists, message);
    public static Error UserNotAuthorized(string message = "User not authorized") => new(ErrorCode.UserNotAuthorized, message);
    
    public static Error InvitationNotFound(string message = "Invitation not found") => new(ErrorCode.InvitationNotFound, message);
    public static Error InvitationAlreadyAccepted(string message = "Invitation already accepted") => new(ErrorCode.InvitationAlreadyAccepted, message);
    public static Error InvitationAlreadyDeclined(string message = "Invitation already declined") => new(ErrorCode.InvitationAlreadyDeclined, message);
    public static Error InvitationExpired(string message = "Invitation expired") => new(ErrorCode.InvitationExpired, message);
    
    
    public static Error NoError => new(ErrorCode.NoError, "No error occurred");
}