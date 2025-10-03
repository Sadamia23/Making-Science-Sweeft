using System.Globalization;
using System.Text.Json;

namespace SweeftAssignment.Task_8;

public class CountryDataGenerator
{
    public static async Task GenerateCountryDataFiles()
    {
        string apiUrl = "https://restcountries.com/v3.1/all";
        
        using HttpClient client = new HttpClient();
        
        try
        {
            string jsonResponse = await client.GetStringAsync(apiUrl);
            
            using JsonDocument doc = JsonDocument.Parse(jsonResponse);
            JsonElement root = doc.RootElement;
            
            string outputDir = "CountryData";
            Directory.CreateDirectory(outputDir);
            
            int fileCount = 0;
            
            foreach (JsonElement country in root.EnumerateArray())
            {
                try
                {
                    string countryName = GetCountryName(country);
                    if (string.IsNullOrEmpty(countryName))
                        continue;
                    
                    string safeFileName = GetSafeFileName(countryName);
                    string filePath = Path.Combine(outputDir, $"{safeFileName}.txt");
                    
                    string region = GetStringValue(country, "region");
                    string subregion = GetStringValue(country, "subregion");
                    string latlng = GetLatLng(country);
                    string area = GetNumberValue(country, "area");
                    string population = GetNumberValue(country, "population");
                    
                    using StreamWriter writer = new StreamWriter(filePath);
                    writer.WriteLine($"Country: {countryName}");
                    writer.WriteLine($"Region: {region}");
                    writer.WriteLine($"Subregion: {subregion}");
                    writer.WriteLine($"Latlng: {latlng}");
                    writer.WriteLine($"Area: {area}");
                    writer.WriteLine($"Population: {population}");
                    
                    fileCount++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
            Console.WriteLine($"Succesfully created {fileCount} file in directory: '{outputDir}'");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    private static string GetCountryName(JsonElement country)
    {
        if (country.TryGetProperty("name", out JsonElement nameElement))
        {
            if (nameElement.TryGetProperty("common", out JsonElement commonName))
            {
                return commonName.GetString() ?? "";
            }
        }
        return "";
    }
    
    private static string GetStringValue(JsonElement country, string propertyName)
    {
        if (country.TryGetProperty(propertyName, out JsonElement element))
        {
            return element.GetString() ?? "N/A";
        }
        return "N/A";
    }
    
    private static string GetNumberValue(JsonElement country, string propertyName)
    {
        if (country.TryGetProperty(propertyName, out JsonElement element))
        {
            if (element.ValueKind == JsonValueKind.Number)
            {
                return element.GetDouble().ToString("N0");
            }
        }
        return "N/A";
    }
    
    private static string GetLatLng(JsonElement country)
    {
        if (country.TryGetProperty("latlng", out JsonElement latlngElement))
        {
            if (latlngElement.ValueKind == JsonValueKind.Array)
            {
                var coords = new List<string>();
                foreach (JsonElement coord in latlngElement.EnumerateArray())
                {
                    coords.Add(coord.GetDouble().ToString(CultureInfo.InvariantCulture));
                }
                return string.Join(", ", coords);
            }
        }
        return "N/A";
    }
    
    private static string GetSafeFileName(string fileName)
    {
        char[] invalidChars = Path.GetInvalidFileNameChars();
        foreach (char c in invalidChars)
        {
            fileName = fileName.Replace(c, '_');
        }
        return fileName.Replace(" ", "_");
    }
}