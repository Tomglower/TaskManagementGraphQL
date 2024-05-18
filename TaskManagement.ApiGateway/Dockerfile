FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TaskManagement.ApiGateway/TaskManagement.ApiGateway.csproj", "TaskManagement.ApiGateway/"]
RUN dotnet restore "TaskManagement.ApiGateway/TaskManagement.ApiGateway.csproj"
COPY . .
WORKDIR "/src/TaskManagement.ApiGateway"
RUN dotnet build "TaskManagement.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagement.ApiGateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagement.ApiGateway.dll"]
