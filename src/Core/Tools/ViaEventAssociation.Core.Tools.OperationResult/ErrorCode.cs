namespace ViaEventAssociation.Core.Tools.OperationResult;

public enum ErrorCode
{
    NoError = 0,

    // HTTP Error Codes
    BadRequest = 400,
    Unauthorized = 401,
    Forbidden = 403,
    NotFound = 404,
    Teapot = 418,
    InternalServerError = 500,

    // Event-specific errors
    EventNotFound = 2001,
    EventAlreadyActive = 2002,
    EventNotReady = 2003,
    EventFull = 2004,
    EventAlreadyExists = 2005,

    // User-specific errors
    UserNotFound = 3001,
    UserAlreadyExists = 3002,
    UserNotAuthorized = 3003,

    // Invitation-specific errors
    InvitationNotFound = 4001,
    InvitationAlreadyAccepted = 4002,
    InvitationAlreadyDeclined = 4003,
    InvitationExpired = 4004
}