using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Shared
{
    [JsonConverter(typeof(JsonStringEnumConverter))]

    public enum Gender2
    {
        [EnumMember(Value = "Female")]
        Female = 1,
        [EnumMember(Value = "Male")]
        Male = 2,
    }
}