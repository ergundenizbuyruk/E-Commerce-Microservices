#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Services/ECommerce.Services.Order/ECommerce.Services.Order.csproj", "Services/ECommerce.Services.Order/"]
COPY ["Shared/ECommerce.Shared/ECommerce.Shared.csproj", "Shared/ECommerce.Shared/"]
RUN dotnet restore "Services/ECommerce.Services.Order/ECommerce.Services.Order.csproj"
COPY . .
WORKDIR "/src/Services/ECommerce.Services.Order"
RUN dotnet build "ECommerce.Services.Order.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ECommerce.Services.Order.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerce.Services.Order.dll"]