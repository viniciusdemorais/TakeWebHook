#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1709 AS build
WORKDIR /src
COPY ["take.webhook.api/take.webhook.api.csproj", "take.webhook.api/"]
RUN dotnet restore "take.webhook.api/take.webhook.api.csproj"
COPY . .
WORKDIR "/src/take.webhook.api"
RUN dotnet build "take.webhook.api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "take.webhook.api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "take.webhook.api.dll"]