GlobalDateConverter is a versatile .NET library designed to convert Gregorian dates and times into various languages and calendar systems, making it ideal for global applications. Whether you're developing for a multilingual audience or need to present dates and times in different cultural formats, GlobalDateConverter provides an easy and reliable solution.

Features
Date Conversion: Convert Gregorian dates to localized date formats using different languages and calendars.
Time Conversion: Convert times to localized formats, including proper numeral translation.
Wide Culture Support: Supports a vast range of cultures, including but not limited to English, Spanish, French, German, Arabic, Hindi, Bengali, Chinese, Japanese, and more.
Calendar Specifics: Handles calendar-specific details such as month names and day formatting.
Easy Integration: Simple API for quick integration into any .NET project.

Installation
You can install the package via NuGet Package Manager Console:

Install-Package GlobalDateConverter

Or via .NET CLI:
dotnet add package GlobalDateConverter

string banglaDate = GlobalDateConverter.DateConverter.ConvertDate(System.DateTime.Now, "bn-BD");
Console.WriteLine(banglaDate);
