FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR ShowMeTheGoodsDemo/
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ShowMeTheGoodsDemo.csproj", "."]
RUN dotnet restore "./ShowMeTheGoodsDemo.csproj"
COPY . .
WORKDIR "/ShowMeTheGoodsDemo/."
RUN dotnet build "ShowMeTheGoodsDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ShowMeTheGoodsDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "api.dll"]