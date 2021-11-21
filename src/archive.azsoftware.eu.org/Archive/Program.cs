string baseDirectory = Directory.GetCurrentDirectory().Replace(@"\", "/").Replace("/src/archive.azsoftware.eu.org/Archive/bin/Debug/net6.0", string.Empty) + "/";
string inputDirectory = baseDirectory + "/input";
string outputDirectory = baseDirectory + "/output";
string templateDirectory = baseDirectory + "/template";
string htmlRow = "<tr><td class=\"text-truncate\" style=\"max-width: 200px;\">{name}</td><td class=\"text-truncate\" style=\"max-width: 200px;\">{name.description}</td><td>{name.framework}</td><td class=\"text-center\"><a href=\"{name.link}\">Download</a></td></tr>";

List<string> arrayTypes = new List<string>();
string compleatedArray = string.Empty;

foreach (string file in Directory.GetFiles(inputDirectory))
{
    Console.WriteLine("pass");
    arrayTypes.Add($"<tr><td class=\"text-truncate\" style=\"max-width: 200px;\">{file.Replace(inputDirectory, string.Empty).Replace(@"\", "/").Trim('/').Replace("-main.zip", string.Empty)}</td><td class=\"text-truncate\" style=\"max-width: 200px;\">{"invalid"}</td><td>{"invalid"}</td><td class=\"text-center\"><a href=\"{"https://github.com/AZProductions/Archive/raw/main/input/" + file.Replace(inputDirectory, string.Empty).Replace(@"\", "/").Trim('/')}\">Download</a></td></tr>");
}
string input = File.ReadAllText(templateDirectory + "/index.html");

foreach (string type in arrayTypes)
    compleatedArray = compleatedArray + type;

input = input.Replace(htmlRow, compleatedArray);

Console.WriteLine(input);

File.WriteAllText(outputDirectory + "/index.html", input);