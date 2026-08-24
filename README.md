# ⚡ Pxoqxo.Quick
Pxoqxo.Quick is a exception-free C# library built for .NET developers. It provides simple methods for everyday, repetitive micro-tasks. Every method handles exceptions internally.

Instead of writing repetitive try-catch blocks, you get clean feedback. Methods return a boolean or a nullable object. If a task fails, it returns false or null. This allows you to write faster, cleaner, and more readable code.

## Key Features
+ Exception-free execution via internal error handling.
+ Boolean or nullable return types for intuitive feedback.
+ Drastically reduces boilerplate try-catch code block noise.

## Usage Examples

### 1. Safe JSON Serialization & Deserialization (QuickJson)
```csharp
// Create a dummy object
var user = new { Name = "Alice", Age = 30 };

// Convert object to JSON string safely
string? jsonString = QuickJson.ToJson(user);
if (jsonString == null) 
{
    Console.WriteLine("Error: Serialization failed.");
    return;
}

// Print JSON if successful
Console.WriteLine("Serialized JSON: " + jsonString);

// Convert JSON string back to an object safely
// Returns default/null if the JSON string is invalid or corrupted
var deserializedUser = QuickJson.FromJson<User>(jsonString);
```

### 2. Safe File Operations (QuickFile)
```csharp
string filePath = @"C:\MyApp\Logs\log.txt";
string content = "Hello World!";

// Write data safely (Automatically creates directories if they don't exist)
bool writeSuccess = QuickFile.Write(filePath, content, append: false);
if (writeSuccess)
{
    Console.WriteLine("File saved successfully.");
}

// Read data safely
// Returns null if the file does not exist, path is empty, or access is denied
string? fileData = QuickFile.Read(filePath);
if (fileData != null)
{
    Console.WriteLine("File Content: " + fileData);
}
```

## 🛠️ Prerequisites
- **Pxoqxo.Quick (em1.0)**
  - .NET 8 SDK (or newer)
  - Pxoqxo.Ext (em1.0)
    - Pxoqxo.Ext.Core
- **Pxoqxo.Quick.Tests (em1.0)**
  - .NET 8 SDK (or newer)
  - Pxoqxo.Quick (em1.0)
  - Pxoqxo.UnitTest (em1.0)
  - Pxoqxo.Ext (em1.0)
    - Pxoqxo.Ext.Core

## 🤝 Contributing
We love **FOSS** contributions! At this time, contributions are accepted only through email. If you'd like to report a bug, suggest a feature, or contribute code, please contact me via pxoqxo@atomicmail.io.

## 📜 License
This project is licensed under the MIT License. See the LICENSE file for the full license text.
