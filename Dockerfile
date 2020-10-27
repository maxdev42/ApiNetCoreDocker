FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base 
WORKDIR /app  

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build 

WORKDIR /src 
COPY web_api.csproj web_api/ 
RUN dotnet restore web_api/web_api.csproj 
WORKDIR /src/web_api 
COPY . . 
RUN dotnet build web_api.csproj -c Release -o /app

FROM build AS publish 
RUN dotnet publish web_api.csproj -c Release -o /app  

COPY --from=build /usr/share/dotnet /usr/share/dotnet

FROM base AS final 
COPY --from=publish /app . 
ENTRYPOINT ["dotnet", "web_api.dll"]