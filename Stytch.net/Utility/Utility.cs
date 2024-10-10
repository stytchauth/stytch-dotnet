using System;
using System.Collections.Generic;

public static class Utility
{
    public static string BuildQueryString(Dictionary<string, string> parameters)
    {
        var queryString = new List<string>();

        foreach (var param in parameters)
        {
            if (string.IsNullOrEmpty(param.Value))
            {
                continue;
            }
            string encodedKey = Uri.EscapeDataString(param.Key);
            string encodedValue = Uri.EscapeDataString(param.Value);

            queryString.Add($"{encodedKey}={encodedValue}");
        }

        return string.Join("&", queryString);
    }
}
