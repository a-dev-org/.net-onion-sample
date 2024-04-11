using System.Net;

namespace Application.Responses;

public record BaseResponseDto(bool IsSuccess, HttpStatusCode ResponseCode = HttpStatusCode.InternalServerError, string? ErrorMessage = null);

public record ResponseDto<T>(
    T Content,
    bool IsSuccess,
    HttpStatusCode ResponseCode = HttpStatusCode.InternalServerError,
    string? ErrorMessage = null) : BaseResponseDto(IsSuccess, ResponseCode, ErrorMessage);