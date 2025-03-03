using webApp.Controllers.Enums;

namespace webApp.Helpers;

public class QueryObj
{
    public StatusOfTheTask? StatusOfTheTask { get; set; }
    public bool? SortByPriority { get; set; }
}