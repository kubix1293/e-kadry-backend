FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine as build

WORKDIR /app
COPY . .
RUN dotnet restore src/API
RUN dotnet publish src/API -c Release -o /build

FROM mcr.microsoft.com/dotnet/runtime:3.1-buster-slim as runtime

WORKDIR /app
COPY --from=build /build .
ENTRYPOINT ["dotnet", "EKadry.API.dll"]
