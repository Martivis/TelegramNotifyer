#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Notifyer.Systems.TgNotifyer/Notifyer.Systems.TgNotifyer.csproj", "Systems/Notifyer.Systems.TgNotifyer/"]
COPY ["Data/Notifyer.Data.Context/Notifyer.Data.Context.csproj", "Data/Notifyer.Data.Context/"]
COPY ["Data/Notifyer.Data.Context.Entities/Notifyer.Data.Context.Entities.csproj", "Data/Notifyer.Data.Context.Entities/"]
RUN dotnet restore "Systems/Notifyer.Systems.TgNotifyer/Notifyer.Systems.TgNotifyer.csproj"
COPY . .
WORKDIR "/src/Systems/Notifyer.Systems.TgNotifyer"
RUN dotnet build "Notifyer.Systems.TgNotifyer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notifyer.Systems.TgNotifyer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifyer.Systems.TgNotifyer.dll"]