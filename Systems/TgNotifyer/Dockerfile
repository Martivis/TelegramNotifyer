#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/TgNotifyer/TgNotifyer.csproj", "Systems/TgNotifyer/"]
COPY ["Data/Notifyer.Context/Notifyer.Context.csproj", "Data/Notifyer.Context/"]
COPY ["Data/Notifyer.Context.Entities/Notifyer.Context.Entities.csproj", "Data/Notifyer.Context.Entities/"]
RUN dotnet restore "Systems/TgNotifyer/TgNotifyer.csproj"
COPY . .
WORKDIR "/src/Systems/TgNotifyer"
RUN dotnet build "TgNotifyer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TgNotifyer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TgNotifyer.dll"]