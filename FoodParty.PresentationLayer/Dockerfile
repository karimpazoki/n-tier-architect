#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["FoodParty.PresentationLayer/FoodParty.PresentationLayer.csproj", "FoodParty.PresentationLayer/"]
RUN dotnet restore "FoodParty.PresentationLayer/FoodParty.PresentationLayer.csproj"
COPY . .
WORKDIR "/src/FoodParty.PresentationLayer"
RUN dotnet build "FoodParty.PresentationLayer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FoodParty.PresentationLayer.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FoodParty.PresentationLayer.dll"]