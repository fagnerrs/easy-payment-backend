FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EP.Products.API/EP.Products.API.csproj", "EP.Products.API/"]
RUN dotnet restore "EP.Products.API/EP.Products.API.csproj"
COPY . .
WORKDIR "/src/EP.Products.API"
RUN dotnet build "EP.Products.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EP.Products.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EP.Products.API.dll"]
