FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EP.Notifications.API/EP.Notifications.API.csproj", "EP.Notifications.API/"]
RUN dotnet restore "EP.Notifications.API/EP.Notifications.API.csproj"
COPY . .
WORKDIR "/src/EP.Notifications.API"
RUN dotnet build "EP.Notifications.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EP.Notifications.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EP.Notifications.API.dll"]
