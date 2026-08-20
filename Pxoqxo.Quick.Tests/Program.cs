using Pxoqxo.Ext.Core;
using Pxoqxo.Quick;
using Pxoqxo.UnitTest;
using System.Text.Json.Serialization;

string? json = null;

Test.Run(() =>
{
    json = QuickJson.ToJson(new DemoDm());
    return !json.IsNullOrEmptyOrWhiteSpace();
});

Test.Run(() =>
{
    DemoDm? demoDm = QuickJson.FromJson<DemoDm>(json ?? string.Empty);

    if (demoDm == null)
    {
        return false;
    }

    return demoDm.Name == "Hello pxoqxo!";
});

Test.Run(() =>
{
    return QuickFile.Write("temp.txt", "Data1\r\n");
});

Test.Run(() =>
{
    return QuickFile.Write("temp.txt", "Data2\r\n", true);
});

Test.Run(() =>
{
    string? data = QuickFile.Read("temp.txt");
    if (data.IsNullOrEmptyOrWhiteSpace())
    {
        return false;
    }

    return data == "Data1\r\nData2\r\n";
});

Console.ReadKey();

public class DemoDm
{
    [JsonPropertyName("name")]
    public string Name { set; get; } = "Hello pxoqxo!";
}
