#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ECommerce.IdentityServer/ECommerce.IdentityServer.csproj", "ECommerce.IdentityServer/"]
COPY ["Shared/ECommerce.Shared/ECommerce.Shared.csproj", "Shared/ECommerce.Shared/"]
RUN dotnet restore "ECommerce.IdentityServer/ECommerce.IdentityServer.csproj"
COPY . .
WORKDIR "/src/ECommerce.IdentityServer"
RUN dotnet build "ECommerce.IdentityServer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.IdentityServer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.IdentityServer.dll"]