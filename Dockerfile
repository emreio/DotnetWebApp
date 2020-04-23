FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY EmreDotnetTest.csproj .
COPY Program.cs .
RUN dotnet build ./EmreDotnetTest.csproj
RUN dotnet publish -c Release -o out