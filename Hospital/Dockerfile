#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
RUN groupadd -r user -g 443 && \
    useradd -u 101 -r -g user newuser
USER newuser

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
COPY ["init.sql", "app/scripts/"]
WORKDIR /src
COPY ["HospitalAPI/HospitalAPI.csproj", "HospitalAPI/"]
RUN dotnet restore "HospitalAPI/HospitalAPI.csproj"

WORKDIR "/src/HospitalAPI"
COPY "/HospitalAPI" .
RUN dotnet build "HospitalAPI.csproj" -c Release -o /app/build

FROM build AS publish
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet publish "HospitalAPI.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
WORKDIR /app/publish
VOLUME /app/scripts
ENTRYPOINT ["dotnet", "HospitalAPI.dll"]