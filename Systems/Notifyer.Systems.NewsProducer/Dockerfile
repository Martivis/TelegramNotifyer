#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Systems/Notifyer.Systems.NewsProducer/Notifyer.Systems.NewsProducer.csproj", "Systems/Notifyer.Systems.NewsProducer/"]
RUN dotnet restore "Systems/Notifyer.Systems.NewsProducer/Notifyer.Systems.NewsProducer.csproj"
COPY . .
WORKDIR "/src/Systems/Notifyer.Systems.NewsProducer"
RUN dotnet build "Notifyer.Systems.NewsProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Notifyer.Systems.NewsProducer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notifyer.Systems.NewsProducer.dll"]