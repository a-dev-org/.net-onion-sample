namespace Application.Responses;

public record AppointmentOverviewDto(List<AppointmentSummaryDto> Appointments);

public record AppointmentSummaryDto(int Id, int AppointmentTypeId, decimal Cost);