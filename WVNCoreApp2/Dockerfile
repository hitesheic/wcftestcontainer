#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0-nanoserver-20H2 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-nanoserver-20H2 AS build
WORKDIR /src
COPY ["WVNCoreApp2/WVNCoreApp2.csproj", "WVNCoreApp2/"]
RUN dotnet restore "WVNCoreApp2/WVNCoreApp2.csproj"
COPY . .
WORKDIR "/src/WVNCoreApp2"
RUN dotnet build "WVNCoreApp2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WVNCoreApp2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WVNCoreApp2.dll"]