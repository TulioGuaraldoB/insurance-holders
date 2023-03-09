using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using InsuranceHolders.Domain.Models;

namespace InsuranceHolders.Web.Dtos
{
    public class HolderDto
    {
        public HolderResponse ParseHolderToResponse(Holder holder)
        {
            return new HolderResponse
            {
                Name = holder.Name,
                DocumentCode = holder.DocumentCode,
            };
        }

        public Holder ParseRequestToHolder(HolderRequest request)
        {
            return new Holder
            {
                Name = request.Name,
                DocumentCode = request.DocumentCode,
            };
        }

        public List<HolderResponse> ParseHoldersToResponse(List<Holder> holders)
        {
            return holders.Select(holderResponse => new HolderResponse
            {
                Name = holderResponse.Name,
                DocumentCode = holderResponse.DocumentCode,
            }).ToList();
        }
    }

    public class HolderResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("document_code")]
        public int DocumentCode { get; set; }
    }

    public class HolderRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("document_code")]
        public int DocumentCode { get; set; }
    }
}