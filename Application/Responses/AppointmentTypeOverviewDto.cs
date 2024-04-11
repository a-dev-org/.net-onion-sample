namespace Application.Responses;

public record AppointmentTypeOverviewDto(List<AppointmentTypeSummaryDto> AppointmentTypes);

public record AppointmentTypeSummaryDto(int Id, string Name, int CategoryId);