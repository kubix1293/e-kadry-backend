FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine

WORKDIR /app
COPY . .

RUN dotnet restore && dotnet build -c Release

CMD ["dotnet", "run", "-c Release --no-build --no-restore"]
