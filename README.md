# PhotoAlbumKata

# Install SDK
This kata was done using .Net Core 2.1 SDK. Anyone who would attempt to run this on their computer may need to install the net core 2.1 SDK
The SDK can be found here: https://dotnet.microsoft.com/download/dotnet-core/2.1

# How to run tests
Inside of visual studio, you can go to your test window and select run and the tests will run. If you want to run it from the command line, you will need to go to the project folder Tests and then execute the command dotnet test and you should see 3 passing tests.

# How to run
I ran the application inside of Visual Studio 2017. You can build the application using visual studio by using the shortcut ctrl F5 to
run with debugging or F5 to run without debugging. If you do this you will need to add an argument for the console application.
This can be done by going to the properties of the PhotoAlbumConsoleApp, go to debug section, and in application arguments type in
an integer value. You can also run it using dotnet build, followed by going to the project folder PhotoAlbumConsoleApp, and then typing
dotnet run -- 2. The number 2 can be any integer.

# Motivation for Solution
I purposely made this slightly more complicated than it needed to be. This was in order to showcase my understanding of depency injection, appropriate abstractions, design patterns (Repository pattern), testability, and to mimic a web api. This problem could be easily solved using just the main method, however then that would lead itself to be difficult to test and not showcase any understanding than just basic
C# knowledge.
