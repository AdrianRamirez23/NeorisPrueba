using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Neoris.Models.DTO
{
    public class ResultDto
    {
        [JsonPropertyName("estado")]
        public bool Estado { get; set; }
        [JsonPropertyName("mensaje")]
        public string Mensaje { get; set; }
        [JsonPropertyName("result")]
        public Object Result { get; set; }
    }
}
