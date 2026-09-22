# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy the project file and restore dependencies.
COPY StudyFlowApi.csproj ./
RUN dotnet restore

# Copy the remaining application files.
COPY . ./

# Build and publish the API.
RUN dotnet publish -c Release -o /app/publish --no-restore


# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copy the published application into the runtime image.
COPY --from=build /app/publish .

# Render provides the PORT environment variable.
# 10000 is Render's default port.
CMD ["sh", "-c", "dotnet StudyFlowApi.dll --urls http://0.0.0.0:${PORT:-10000}"]