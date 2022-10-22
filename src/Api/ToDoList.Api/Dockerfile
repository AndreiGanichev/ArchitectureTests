FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Api/ToDoList.Api/ToDoList.Api.csproj", "ToDoList.Api/"]
RUN dotnet restore "Api/ToDoList.Api/ToDoList.Api.csproj"
COPY . .
WORKDIR "/src/ToDoList.Api"
RUN dotnet build "ToDoList.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDoList.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDoList.Api.dll"]
