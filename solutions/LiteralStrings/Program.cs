var str1 = @"This is a verbatim string literal. \
backslashes are not escape characters here.";
Console.WriteLine(str1);

var str2 = $"This is an interpolated string. Today's date is {DateTime.Now}.";
Console.WriteLine(str2);

var str3 = $@"This is a verbatim interpolated string. 
Today's date is {DateTime.Now}.";
Console.WriteLine(str3);

var str4 = """
    This is a raw string literal.
    Newlines are "preserved."
        Indentaion is preserved beyond the closing quotes.
    """;
Console.WriteLine(str4);