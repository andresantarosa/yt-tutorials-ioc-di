#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["IoC_DependecyInjection/IoC_DependecyInjection.csproj", "IoC_DependecyInjection/"]
RUN dotnet restore "IoC_DependecyInjection/IoC_DependecyInjection.csproj"
COPY . .
WORKDIR "/src/IoC_DependecyInjection"
RUN dotnet build "IoC_DependecyInjection.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "IoC_DependecyInjection.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IoC_DependecyInjection.dll"]