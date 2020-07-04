using Newtonsoft.Json;

namespace WebServicesHomework.Models
{
    public static class Serialize
    {
        public static string ToJson(this Household self) => JsonConvert.SerializeObject(self, WebServicesHomework.Models.Converter.Settings);

        public static string ToJson(this Book self) => JsonConvert.SerializeObject(self, WebServicesHomework.Models.Converter.Settings);

        public static string ToJson(this Link self) => JsonConvert.SerializeObject(self, WebServicesHomework.Models.Converter.Settings);

        public static string ToJson(this User self) => JsonConvert.SerializeObject(self, WebServicesHomework.Models.Converter.Settings);

    }
}
