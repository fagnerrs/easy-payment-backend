FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EP.Payments.API/EP.Payments.API.csproj", "EP.Payments.API/"]
RUN dotnet restore "EP.Payments.API/EP.Payments.API.csproj"
COPY . .
WORKDIR "/src/EP.Payments.API"
RUN dotnet build "EP.Payments.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EP.Payments.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EP.Payments.API.dll"]
