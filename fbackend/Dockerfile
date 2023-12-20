#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build

WORKDIR /app

COPY ./*.csproj .
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out

#Download Microsoft runtime container
FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as runtime

WORKDIR /app

COPY --from=build /app/out .

EXPOSE 80

ENTRYPOINT [ "dotnet", "fbackend.dll" ]
