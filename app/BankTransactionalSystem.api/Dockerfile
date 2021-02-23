#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["BankTransactionalSystem.api/BankTransactionalSystem.api.csproj", "BankTransactionalSystem.api/"]
RUN dotnet restore "BankTransactionalSystem.api/BankTransactionalSystem.api.csproj"
COPY . .
WORKDIR "/src/BankTransactionalSystem.api"
RUN dotnet build "BankTransactionalSystem.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankTransactionalSystem.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankTransactionalSystem.api.dll"]