#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["aula04/src/Aula04.WebApi/Aula04.WebApi.csproj", "aula04/src/Aula04.WebApi/"]
RUN dotnet restore "aula04/src/Aula04.WebApi/Aula04.WebApi.csproj"
COPY . .
WORKDIR "/src/aula04/src/Aula04.WebApi"
RUN dotnet build "Aula04.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aula04.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aula04.WebApi.dll"]