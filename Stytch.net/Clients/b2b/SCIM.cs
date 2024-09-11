// !!!
// WARNING: This file is autogenerated
// Only modify code within MANUAL() sections
// or your changes may be overwritten later!
// !!!

using Newtonsoft.Json;
using Stytch.net.Models.Consumer;
using System.Text;




namespace Stytch.net.Clients.b2b
{
  public class SCIM
  {
    private readonly HttpClient _httpClient;
    public readonly SCIMConnection Connection;
    public SCIM(HttpClient client)
    {
      _httpClient = client;
        Connection = new SCIMConnection(_httpClient);
    }








  }

}
