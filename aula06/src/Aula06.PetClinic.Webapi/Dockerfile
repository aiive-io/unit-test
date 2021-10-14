#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["aula06/src/Aula06.PetClinic.Webapi/Aula06.PetClinic.Webapi.csproj", "aula06/src/Aula06.PetClinic.Webapi/"]
RUN dotnet restore "aula06/src/Aula06.PetClinic.Webapi/Aula06.PetClinic.Webapi.csproj"
COPY . .
WORKDIR "/src/aula06/src/Aula06.PetClinic.Webapi"
RUN dotnet build "Aula06.PetClinic.Webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aula06.PetClinic.Webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aula06.PetClinic.Webapi.dll"]