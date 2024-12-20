// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Stytch.net.Models.Consumer
{
    public class Attributes
    {
        /// <summary>
        /// The IP address of the user.
        /// </summary>
        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }
        /// <summary>
        /// The user agent of the User.
        /// </summary>
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
    }

}
