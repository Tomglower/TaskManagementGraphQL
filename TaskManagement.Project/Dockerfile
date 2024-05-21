FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["TaskManagement.Project/TaskManagement.Project.csproj", "TaskManagement.Project/"]
RUN dotnet restore "TaskManagement.Project/TaskManagement.Project.csproj"
COPY . .
WORKDIR "/src/TaskManagement.Project"
RUN dotnet build "TaskManagement.Project.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagement.Project.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagement.Project.dll"]
