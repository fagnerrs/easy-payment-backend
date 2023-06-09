FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EP.Users.API/EP.Users.API.csproj", "EP.Users.API/"]
RUN dotnet restore "EP.Users.API/EP.Users.API.csproj"
COPY . .
WORKDIR "/src/EP.Users.API"
RUN dotnet build "EP.Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EP.Users.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EP.Users.API.dll"]
