#=======================================================================
# Stage 1: Build & Publish the Application
#=======================================================================
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /src

# Copy the .csproj file and restore dependencies
COPY ["FitnessTracker.csproj", "./"]
RUN dotnet restore "FitnessTracker.csproj"

# Copy rest of the code
COPY . .

# Build and Publish the app in Release mode
RUN dotnet publish "FitnessTracker.csproj" -c Release -o /app/publish /p:UseAppHost=false

#=======================================================================
# Stage 2: Runtime Image for production
#=======================================================================
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy published files from the builder stage
COPY --from=builder /app/publish/ .

# Exposing the ports for application to listen 
EXPOSE 8080

# setting entrypoint to run the application
ENTRYPOINT ["dotnet", "FitnessTracker.dll"]
