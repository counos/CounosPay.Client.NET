using System;
using CounosPayClient.Api.V1.Inf;
using Newtonsoft.Json;

namespace CounosPayClient.Api.V1.Models
{
	[Serializable]
    public class Ticker
    {
	    private string _titleLocal;

	    public Ticker(int id,string title, string name, string shortname,TickerTypes type)
        {
            TickerId = id;
            Title = title;
            Name = name;
            ShortName = shortname;
            Type = type;
        }

        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
        public int TickerId { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
		public string Title { get; set; }

	    [JsonIgnore]
	    public string TitleLocal
	    {
		    get => _titleLocal??Title;
	        set => _titleLocal = value;
	    }

	    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
		public string Name { get; set; }

	    [JsonProperty("short_name", NullValueHandling = NullValueHandling.Ignore)]
		public string ShortName { get; set; }

		[JsonIgnore]
	    public bool IsValid => !string.IsNullOrEmpty(ShortName);

        [JsonProperty("type")]
        public TickerTypes Type { get; set; }
    }
}
