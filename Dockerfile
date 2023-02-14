FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BikeGarageAPI.csproj", "./"]
RUN dotnet restore "BikeGarageAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "BikeGarageAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BikeGarageAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BikeGarageAPI.dll"]