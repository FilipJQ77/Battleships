FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BattleshipsAPI/BattleshipsAPI.csproj", "BattleshipsAPI/"]
RUN dotnet restore "BattleshipsAPI/BattleshipsAPI.csproj"
COPY . .
WORKDIR "/src/BattleshipsAPI"
RUN dotnet build "BattleshipsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BattleshipsAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BattleshipsAPI.dll"]
