FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EDA.Consumer.Demo/EDA.Consumer.Demo.csproj", "EDA.Consumer.Demo/"]
RUN dotnet restore "EDA.Consumer.Demo/EDA.Consumer.Demo.csproj"
COPY . .
WORKDIR "/src/EDA.Consumer.Demo"
RUN dotnet build "EDA.Consumer.Demo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EDA.Consumer.Demo.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EDA.Consumer.Demo.dll"]
