#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/Contact.API/Contact.API.csproj", "Services/Contact.API/"]
COPY ["Contact.API.Infrastructure/Contact.API.Infrastructure.csproj", "Contact.API.Infrastructure/"]
COPY ["Contact.API.Models/Contact.API.Models.csproj", "Contact.API.Models/"]
COPY ["Contact.API.Services/Contact.API.Services.csproj", "Contact.API.Services/"]
RUN dotnet restore "Services/Contact.API/Contact.API.csproj"
COPY . .
WORKDIR "/src/Services/Contact.API"
RUN dotnet build "Contact.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Contact.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Contact.API.dll"]