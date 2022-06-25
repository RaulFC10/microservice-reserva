FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
EXPOSE 80
WORKDIR /src

COPY ["./Reservas.WebApi/Reservas.WebApi.csproj", "src/Reservas.WebApi/"]

RUN dotnet restore "src/Reservas.WebApi/Reservas.WebApi.csproj"

COPY . .

WORKDIR "/src/Reservas.WebApi/"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "Reservas.WebApi.dll" ]