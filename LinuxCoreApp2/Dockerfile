#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LinuxCoreApp2/LinuxCoreApp2.csproj", "LinuxCoreApp2/"]
RUN dotnet restore "LinuxCoreApp2/LinuxCoreApp2.csproj"
COPY . .
WORKDIR "/src/LinuxCoreApp2"
RUN dotnet build "LinuxCoreApp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LinuxCoreApp2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LinuxCoreApp2.dll"]