using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

try
{
    while (true)
    {
        Registration registration = new();
        registration.UserId = 275;
        registration.DateTime = RandomTime.RandomDay();
        using HttpClient httpClient = new HttpClient();
        httpClient.BaseAddress = new Uri("https://api.balleby.org/");
        var stringContent = new StringContent(JsonSerializer.Serialize(registration, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }), Encoding.UTF8, "application/json");
        var result = await httpClient.PostAsync("buffet", stringContent);
    }
}
catch (Exception)
{

}

internal class Registration
{
    private DateTime datetime;
    public int? Id { get; set; }
    public int UserId { get; set; }
    public DateTime DateTime { get { return datetime; } set {datetime = value; } }
}
internal class RandomTime
{
    public static DateTime RandomDay()
    {
        Random gen = new();
        DateTime start = new DateTime(2017, 1, 1);
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }
}