#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["fictivusforum_topicservice.csproj", "."]
RUN dotnet restore "fictivusforum_topicservice.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "fictivusforum_topicservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fictivusforum_topicservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fictivusforum_topicservice.dll"]
