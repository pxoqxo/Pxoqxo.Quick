using Pxoqxo.Ext.Core;
using Pxoqxo.Quick;
using Pxoqxo.UnitTest;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

string? json = null;
string? xml = null;

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
    xml = QuickXml.ToXml(new DemoDm());
    return !xml.IsNullOrEmptyOrWhiteSpace();
});

Test.Run(() =>
{
    DemoDm? demoDm = QuickXml.FromXml<DemoDm>(xml ?? string.Empty);

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

[XmlRoot("demo")]
public class DemoDm
{
    [JsonPropertyName("name")]
    [XmlElement("name")]
    public string Name { set; get; } = "Hello pxoqxo!";
}
