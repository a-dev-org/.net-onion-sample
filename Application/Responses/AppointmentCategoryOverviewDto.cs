namespace Application.Responses;

public record AppointmentCategoryOverviewDto(List<AppointmentCategorySummaryDto> AppointmentCategories);

public record AppointmentCategorySummaryDto(int Id, string Name);