using System.Text.Json.Serialization;

namespace PrimeiraAPI.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TurnoEnum 
    {
        Manha,
        Tarde,
        Noite
    }
}
