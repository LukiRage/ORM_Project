# Use an official .NET runtime as the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the project files to the container
COPY . .

# Restore the NuGet packages
RUN dotnet restore

# Build the application
RUN dotnet build --configuration Release --no-restore

# Publish the application
RUN dotnet publish --configuration Release --no-build --output ./publish

# Use a lightweight .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

# Set the working directory in the container
WORKDIR /app

# Copy the published output from the build stage to the container
COPY --from=build /app/publish .

# Expose the necessary ports
ENV ASPNETCORE_URLS=http://*:8000
EXPOSE 8000

# Set the entry point to run the server
CMD ["dotnet", "ORM_Projekt.dll"]

# syntax=docker/dockerfile:1
# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
# WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY *.csproj ./
# RUN dotnet restore
# ENV ASPNETCORE_URLS=http://*:8000
# # Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# COPY bin/Debug/net6.0/ App/
# WORKDIR /App
# ENTRYPOINT ["dotnet", "ORM_Projekt.dll"]