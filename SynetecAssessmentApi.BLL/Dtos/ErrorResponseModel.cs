using Newtonsoft.Json;

namespace SynetecAssessmentApi.BLL.Dtos
{
    public class ErrorResponseModel
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}