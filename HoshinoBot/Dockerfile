FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HoshinoBot/HoshinoBot.csproj", "HoshinoBot/"]
RUN dotnet restore "HoshinoBot/HoshinoBot.csproj"
COPY . .
WORKDIR "/src/HoshinoBot"
RUN dotnet build "HoshinoBot.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HoshinoBot.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HoshinoBot.dll"]
