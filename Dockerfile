#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Wallet.API/Wallet.API.csproj", "Wallet.API/"]
COPY ["Wallet.Dtos/Wallet.Dtos.csproj", "Wallet.Dtos/"]
COPY ["Wallet.Model/Wallet.Model.csproj", "Wallet.Model/"]
COPY ["Wallet.Core/Wallet.Core.csproj", "Wallet.Core/"]
COPY ["Wallet.Data/Wallet.Data.csproj", "Wallet.Data/"]
COPY ["Wallet.Utilties/Wallet.Utilties.csproj", "Wallet.Utilties/"]
RUN dotnet restore "Wallet.API/Wallet.API.csproj"
COPY . .
WORKDIR "/src/Wallet.API"
RUN dotnet build "Wallet.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Wallet.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

#ENTRYPOINT ["dotnet", "Wallet.API.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Wallet.API.dll
